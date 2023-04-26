using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
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
        HurtBox OtherHurtBox;
        if(other.TryGetComponent<HurtBox>(out OtherHurtBox))
        {
            Debug.Log("A hit happened");
            if(OtherHurtBox.transform.parent != transform.parent) SendMessageUpwards("OnHit",OtherHurtBox, SendMessageOptions.DontRequireReceiver);
        }
    }
}
