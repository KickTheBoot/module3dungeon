using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionableGroup : Transitionable
{
    [SerializeField]Transitionable[] transitionables;
    public override void SetValue(float value)
    {
        foreach(Transitionable transitionable in transitionables)
        {
            transitionable.SetValue(value);
        }
    }
}
