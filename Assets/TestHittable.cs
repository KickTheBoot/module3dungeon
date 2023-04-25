using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHittable : MonoBehaviour
{
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnHit(HurtBox other)
    {
        Debug.Log("Hit!");
        sprite.color = Color.red;
    }

    void OnHit()
    {
        Debug.Log("Hit!");
        sprite.color = Color.red;
    }
}
