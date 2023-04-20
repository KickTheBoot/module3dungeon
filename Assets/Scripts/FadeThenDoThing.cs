using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeThenDoThing : MonoBehaviour
{
    [SerializeField]Image picture;
    [SerializeField]Color DefaultColor, FadedColor;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator FadeSceneTransition(float FadeInTime, float FadeOutime)
    {   //Fade out
        float FastFadeInTime = 1/FadeInTime;
        for(float t = 0; t < FadeInTime; t += Time.deltaTime)
        {
            picture.color = Color.Lerp(FadedColor, DefaultColor, t*FastFadeInTime);
            yield return null;
        }
        Debug.Log("Did the thing!");
        //Fade in
        float FastFadeOutTime = 1/FadeOutime;
        for(float t = 0; t < FadeOutime; t += Time.deltaTime)
        {
            picture.color = Color.Lerp(DefaultColor, FadedColor, t*FastFadeOutTime);
            yield return null;
        }
        yield return null;
    }

    void OnGUI()
    {
        if(GUILayout.Button("FadeThingy"))StartCoroutine(FadeSceneTransition(0.5f,1));
    }
}
