using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharVar;

public abstract class Character : MonoBehaviour
{
    public Health health;
    [SerializeField]SpriteRenderer spriteRenderer;
    [SerializeField]AudioClip DamageSound;
    [SerializeField]float invincibilityTime;
    float elapsedInvincibilityTime;

    public virtual void Awake()
    {
        health.OnDeath += OnDeath;
    }

    public abstract void OnDeath();
    
    public virtual void OnHit(HurtBox other)
    {
        if(elapsedInvincibilityTime == 0 || elapsedInvincibilityTime >= invincibilityTime)
        {
            AudioSource.PlayClipAtPoint(DamageSound,transform.position);
            health.Damage(other.Damage);
            StartCoroutine(invincibilityFrames());
        }
    }

    public virtual IEnumerator invincibilityFrames()
    {
        for(elapsedInvincibilityTime = 0; elapsedInvincibilityTime < invincibilityTime; elapsedInvincibilityTime += Time.deltaTime)
        {   
            spriteRenderer.enabled = elapsedInvincibilityTime % 0.1f > 0.05f;
            yield return null;
        }
        spriteRenderer.enabled = true;
    }



}
