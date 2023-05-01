using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum HitBoxLayer
{
    All,
    Player,
    Enemy
}

public class HurtBox : MonoBehaviour
{
    public HitBoxLayer layer;
    public int Damage;
    public bool DoesKnockBack;

    public bool DestroyAfterHit;

    [Tooltip("If this is set to zero, it will not be destroyed")]
    [Range(0,10)]
    public float Duration;

    public float knockBackForce;

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

    public static HurtBox create(Vector2 Position, Vector2 Size, int Damage, float knockBackForce, bool DestroyAfterHit, float Duration)
    {
        GameObject obj = new GameObject("HurtBox");
        obj.layer = 9;
        obj.transform.position = Position;
        BoxCollider2D coll = obj.AddComponent<BoxCollider2D>();
        coll.size = Size;
        coll.isTrigger = true;
        Rigidbody2D rb = obj.AddComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        HurtBox box = obj.AddComponent<HurtBox>();
        box.Damage = Damage;
        box.knockBackForce = knockBackForce;
        box.DestroyAfterHit = DestroyAfterHit;
        box.Duration = Duration;

    
        return box;
    }
}
