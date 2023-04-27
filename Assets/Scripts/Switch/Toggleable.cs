using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Toggleable : MonoBehaviour
{
    public int booleanIndex;

    void Start()
    {
        OnChange(GameManager.instance.worldVariables.booleans[booleanIndex].value);
    }

    void OnEnable()
    {
        GameManager.instance.worldVariables.booleans[booleanIndex].OnChange += OnChange;
    }

    void OnDisable()
    {
        GameManager.instance.worldVariables.booleans[booleanIndex].OnChange -= OnChange;
    }
    public void Toggle()
    {
        GameManager.instance.worldVariables.booleans[booleanIndex].value = !GameManager.instance.worldVariables.booleans[booleanIndex].value;
    }

    public void Set(bool value)
    {
         GameManager.instance.worldVariables.booleans[booleanIndex].value = value;
    }

    protected abstract void OnChange(bool value);
}
