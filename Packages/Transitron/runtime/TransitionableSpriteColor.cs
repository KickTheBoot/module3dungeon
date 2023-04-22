using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TransitionableSpriteColor : Transitionable
{
    Image image;

    [SerializeField]Color FadeInColor, FadeOutColor;

    public void Awake()
    {
        image = GetComponent<Image>();
    }

    public override void SetValue(float value)
    {
        image.color = Color.Lerp(FadeInColor, FadeOutColor, value);
    }
}
