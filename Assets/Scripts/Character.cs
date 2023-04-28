using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharVar;

public abstract class Character : MonoBehaviour
{
    public Health health;

    void Awake()
    {
        health.OnDeath += OnDeath;
    }

    public abstract void OnDeath();
    
    
}
