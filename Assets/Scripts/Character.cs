using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharVar;

public abstract class Character : MonoBehaviour
{
    public Health health;
    
    protected void Awake()
    {
        health.OnDeath += DeathActions;
    }

    protected abstract void DeathActions();

}
