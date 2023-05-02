using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuitOnInput : MonoBehaviour
{
    [SerializeField] InputAction Quit;
    
    // Start is called before the first frame update
    void Start()
    {
        Quit.performed += (InputAction.CallbackContext context) => Application.Quit();
        Quit.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
