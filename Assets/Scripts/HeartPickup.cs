using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPickup : ItemPickUp
{

    [SerializeField]int HealAmount;
    protected override void OnPickUp(PlayerCharacter character)
    {
        character.health.Heal(HealAmount);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
