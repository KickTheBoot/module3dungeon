using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour
{
    public int Damage;
    public bool DoesKnockBack;

    public bool DestroyAfterHit;

    [Tooltip("If this is set to zero, it will not be destroyed")]
    [Range(0,10)]
    public float Duration;

    // Start is called before the first frame update
    void Start()
    {
        if(Duration != 0)
        {
            Destroy(this.gameObject,Duration);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(DestroyAfterHit) Destroy(this.gameObject);
    }
}
