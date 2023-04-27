using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : ItemPickUp
{
    public int ID;
    void Start()
    {
        gameObject.SetActive(!GameManager.instance.worldVariables.pickedUpKeys.Contains(ID));
    }
    protected override void OnPickUp(PlayerCharacter character)
    {
         character.KeyCount++;
         GameManager.instance.worldVariables.pickedUpKeys.Add(ID);
    }
}
