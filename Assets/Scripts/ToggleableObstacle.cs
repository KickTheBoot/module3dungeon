using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableObstacle :  Toggleable
{
    [Tooltip("The togglo this obstacle will listen for")]
    public bool invert;
    
    

    protected override void OnChange(bool State)
    {
        int count = transform.childCount;
        for(int i = 0; i < count; i++)
        {
            transform.GetChild(i).gameObject.SetActive(State != invert);
        }
    }
}
