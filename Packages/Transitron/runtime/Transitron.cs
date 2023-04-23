using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Transitron : MonoBehaviour
{
    public Transitionable target;
    [SerializeField] float FadeInTime, FadeOutTime;


    bool Running = false;

    public IEnumerator Fade(Action StartAction, Action MiddleAction, Action EndAction)
    {
        if(!Running && target)
        {
            StartAction();
            float FadeTime;
            float OneDividedByFadeTime = 1 / FadeInTime;
            Debug.Log($"{gameObject.name}: fading in");
            for (FadeTime = 0; FadeTime < FadeInTime; FadeTime += Time.deltaTime)
            {
                target.SetValue(FadeTime * OneDividedByFadeTime);
                yield return null;
            }

            MiddleAction();

            OneDividedByFadeTime = 1/FadeOutTime;
            Debug.Log($"{gameObject.name}: fading out");
            for (FadeTime = 0; FadeTime < FadeOutTime; FadeTime += Time.deltaTime)
            {
                target.SetValue(1 - FadeTime * OneDividedByFadeTime);
                yield return null;
            }
            EndAction();
        }
        else
        {

        }

    }
}
