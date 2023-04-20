using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class EventZone : MonoBehaviour
{
    [Tooltip("If this field is left empty, the event will be alwaysn triggered no matter the collider")]
    enum TargetType
    {
        Tag, Name
    }

    [SerializeField]Event OnTargetEnter;
    [SerializeField]Event OnTargetExit;

    [SerializeField]TargetType targetType;
    [SerializeField] string Target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(Target != "")
        switch(targetType)
        {
            case TargetType.Tag:
            if(other.tag == Target)OnTargetEnter.Use();
            else return;
            break;
            case TargetType.Name:
            if(other.name == Target)OnTargetEnter.Use();
            else return; 
            break;
        }
        else OnTargetEnter.Use();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(Target != "")
        switch(targetType)
        {
            case TargetType.Tag:
            if(other.tag == Target)OnTargetExit.Use();
            else return;
            break;
            case TargetType.Name:
            if(other.name == Target)OnTargetExit.Use();
            else return; 
            break;
        }
        else OnTargetExit.Use();
    }
}
