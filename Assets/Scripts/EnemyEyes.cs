using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEyes : MonoBehaviour
{
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
        SendMessageUpwards("OnSeeObject",other, SendMessageOptions.DontRequireReceiver);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        SendMessageUpwards("OnUnSeeObject", other, SendMessageOptions.DontRequireReceiver);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        SendMessageUpwards("OnObjectInSight", other, SendMessageOptions.DontRequireReceiver);
    }
}
