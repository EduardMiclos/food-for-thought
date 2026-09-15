using UnityEngine;
using UnityEngine.InputSystem;

public class MenuController : MonoBehaviour
{
    public GameObject menuCanvas;

    void Start()
    {
        menuCanvas.SetActive(false);
    }

    void Update()
    {
     
    }

    public void ToggleMenu(InputAction.CallbackContext context)
    {
        Debug.Log("toggle");
        menuCanvas.SetActive(!menuCanvas.activeSelf);
    }
}
