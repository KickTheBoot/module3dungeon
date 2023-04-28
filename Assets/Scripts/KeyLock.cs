using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyLock : Toggleable
{
    [SerializeField]AudioClip UnlockSound;
    protected override void OnChange(bool value)
    {
        gameObject.SetActive(!value);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        PlayerCharacter character;
        if(other.tag == "Player" && other.TryGetComponent<PlayerCharacter>(out character))
        {
            if(character.KeyCount > 0)
            {
                Set(true);
                AudioSource.PlayClipAtPoint(UnlockSound,transform.position);
                character.KeyCount--;
            }
        }
    }


    
}
