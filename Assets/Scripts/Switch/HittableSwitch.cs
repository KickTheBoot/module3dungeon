using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Togglo))]
public class HittableSwitch : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite onSprite, offSprite;
    
    Togglo togglo;
    
    // Start is called before the first frame update
    void Start()
    {
        togglo = GetComponent<Togglo>();
    }

    

    void OnHit(HurtBox other)
    {
        togglo.status = !togglo.status;
        spriteRenderer.sprite = togglo.status ? onSprite : offSprite;
    }



}
