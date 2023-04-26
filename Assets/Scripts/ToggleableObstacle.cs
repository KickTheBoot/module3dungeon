using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleableObstacle : MonoBehaviour
{
    [Tooltip("The togglo this obstacle will listen for")]
    public Togglo togglo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnEnable()
    {
        togglo.OnSwitch += SetChildren;
    }

    void OnDisable()
    {
        togglo.OnSwitch -= SetChildren;
    }

    void SetChildren(bool State)
    {
        int count = transform.childCount;
        for(int i = 0; i < count; i++)
        {
            transform.GetChild(i).gameObject.SetActive(State);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
