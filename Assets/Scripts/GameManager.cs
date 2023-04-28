using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using CharVar;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public WorldVariables worldVariables;

    public GameSettingsScriptableObject GameSettings;
    [SerializeField]UImanager manager;

    [SerializeField] Transitron transitron;


    public InputActionAsset GetInputActions()
    {
        return GameSettings.Controls;
    }
    
    // Start is called before the first frame update
    void Awake()
    {
        if(!instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);

        manager.trackedPlayer = GameObject.Find("Hero").GetComponent<PlayerCharacter>();

        worldVariables.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Warp(WarpInfo warp)
    {
        Debug.Log("Warping");
        PlayerCharacter character = GameObject.Find("Hero").GetComponent<PlayerCharacter>();
        transitron.StartCoroutine(transitron.Fade(GameSettings.Controls.Disable,() => StartCoroutine(WarpAction(warp)),GameSettings.Controls.Enable));
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    IEnumerator WarpAction(WarpInfo warp)
    {
        if(warp.SceneIndex != SceneManager.GetActiveScene().buildIndex)SceneManager.LoadScene(warp.SceneIndex);
        yield return null;
        GameObject character = GameObject.Find("Hero");
        Debug.Log(character);
        character.transform.position = warp.Position;
        Debug.Log($"{warp.Position}, {character.transform.position}");
    }

}
