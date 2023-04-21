using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameSettingsScriptableObject GameSettings;

    [SerializeField] FadeThenDoThing Fader;


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

    public void Warp(WarpInfo warp)
    {
        Debug.Log("Warping");
        PlayerCharacter character = GameObject.Find("Hero").GetComponent<PlayerCharacter>();
        Fader.StartCoroutine(Fader.FadeSceneTransition(0.5f,1,WarpAction(warp)));
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
