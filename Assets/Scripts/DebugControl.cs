using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class DebugControl : MonoBehaviour
{
    public InputAction ReloadScene;

    public InputAction Debug1;
    public UnityEvent OnDebug1Pressed;

    public InputAction Debug2;
    public UnityEvent OnDebug2Pressed;
    // Start is called before the first frame update
    void Start()
    {
        ReloadScene.performed += SceneReload;
        ReloadScene.Enable();

        Debug1.performed += (InputAction.CallbackContext context) => OnDebug1Pressed.Invoke();
        Debug1.Enable();

        Debug2.performed += (InputAction.CallbackContext context) => OnDebug2Pressed.Invoke();
        Debug1.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        ReloadScene.Disable();
    }
    void OnDestroy()
    {
    }

    void SceneReload(InputAction.CallbackContext context)
    {
        Debug.Log("Scene Reloaded!");
        if(context.performed)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex,LoadSceneMode.Single);
    }
}
