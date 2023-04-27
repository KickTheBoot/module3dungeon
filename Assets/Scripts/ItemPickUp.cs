using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemPickUp : MonoBehaviour
{
    protected abstract void OnPickUp(PlayerCharacter character);
    [SerializeField]AudioClip Sound;

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCharacter character;
        if(other.TryGetComponent<PlayerCharacter>(out character))
        {
            OnPickUp(character);
            AudioSource.PlayClipAtPoint(Sound,transform.position);
            gameObject.SetActive(false);
        }
    }
    

    
}
