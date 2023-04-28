using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HittableSwitch : Toggleable
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite onSprite, offSprite;
    
    [SerializeField] AudioClip Sound;
    
    int index;    
    
    protected override void OnChange(bool value)
    {
        spriteRenderer.sprite = value ? onSprite : offSprite;
    }

    

    void OnHit(HurtBox other)
    {
        Toggle();
        AudioSource.PlayClipAtPoint(Sound, transform.position);
    }



}
