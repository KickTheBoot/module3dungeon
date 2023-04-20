using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    GameSettingsScriptableObject GameSettings;

    public InputActionAsset GetInputActions()
    {
        return GameSettings.Controls;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
