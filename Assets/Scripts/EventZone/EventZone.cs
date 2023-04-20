using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;


[RequireComponent(typeof(Collider2D))]
public class EventZone : MonoBehaviour
{
    [Tooltip("If this field is left empty, the event will be alwaysn triggered no matter the collider")]
    enum TargetType
    {
        Tag, Name
    }

    [SerializeField]public UnityEvent OnTargetEnter;
    [SerializeField]public UnityEvent OnTargetExit;

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
        Debug.Log($"{other.tag} entered trigger");
        if(Target != "")
        switch(targetType)
        {
            case TargetType.Tag:
            if(other.tag == Target)OnTargetEnter.Invoke();
            else return;
            break;
            case TargetType.Name:
            if(other.name == Target)OnTargetEnter.Invoke();
            else return; 
            break;
        }
        else OnTargetEnter.Invoke();
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log($"{other.tag} exited trigger");
        if(Target != "")
        switch(targetType)
        {
            case TargetType.Tag:
            if(other.tag == Target)OnTargetExit.Invoke();
            else return;
            break;
            case TargetType.Name:
            if(other.name == Target)OnTargetExit.Invoke();
            else return; 
            break;
        }
        else OnTargetExit.Invoke();
    }
}
