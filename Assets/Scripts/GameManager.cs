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

    [SerializeField]Transitron transitron;

    [SerializeField]WarpInfo GameOverWarp;


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
        Warp(GameOverWarp);
        worldVariables.pickedUpKeys.Clear();
        for(int i = 0; i < worldVariables.booleans.Length;i++)
        {
            worldVariables.booleans[i].value = false;
        }
    }

    IEnumerator WarpAction(WarpInfo warp)
    {
        GameObject character = GameObject.Find("Hero");
        Collider2D coll = character.GetComponent<Collider2D>();
        coll.enabled = false;
        character.transform.position = warp.Position;
        if(warp.SceneIndex != SceneManager.GetActiveScene().buildIndex)SceneManager.LoadScene(warp.SceneIndex);
        yield return null;
        coll.enabled = true;
        character.SetActive(true);
        Debug.Log(character);
        Debug.Log($"{warp.Position}, {character.transform.position}");
    }

}
