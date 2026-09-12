using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 4f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 lastInput;
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveInput != Vector2.zero)
            Move();
        else
            Stay();
    }

    private void Stay()
    {

        rb.linearVelocity = Vector2.zero;
    }

    private void Move()
    {

        rb.linearVelocity = moveInput * moveSpeed;
        lastInput = moveInput;
    } 

    private void animatorStartWalking()
    {
        animator.SetBool("IsWalking", true);
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);
    }

    private void animatorStopWalking()
    {
        animator.SetBool("IsWalking", false);
        animator.SetFloat("LastInputX", lastInput.x);
        animator.SetFloat("LastInputY", lastInput.y);
    }
    
    public void ReadInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (moveInput != Vector2.zero)
            animatorStartWalking();
        else
            animatorStopWalking();
    }
}
