using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public HitBoxLayer layer;
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
            if(OtherHurtBox.layer == this.layer || OtherHurtBox.layer == HitBoxLayer.All) SendMessageUpwards("OnHit",OtherHurtBox, SendMessageOptions.DontRequireReceiver);
        }
    }
}
