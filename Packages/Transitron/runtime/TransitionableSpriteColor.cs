using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TransitionableSpriteColor : Transitionable
{
    SpriteRenderer Renderer;

    Color FadeInColor, FadeOutColor;

    public void Awake()
    {
        Renderer = GetComponent<SpriteRenderer>();
    }

    public override void SetValue(float value)
    {
        Renderer.color = Color.Lerp(FadeInColor, FadeOutColor, value);
    }
}
