using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Health{
    public uint health {get; private set;}
    public uint MaxHealth {get; private set;}

    public Health(uint health, uint MaxHealth)
    {
        this.health = health;
        this.MaxHealth = MaxHealth;
    }

    public void Heal(uint amount)
    {
        if(health + amount > MaxHealth) health = MaxHealth;
    }

    public void Damage(uint amount)
    {
        if(health - amount < 0) health = 0;
        if(health == 0) OnDeath.Invoke();
    }

    public delegate void Death();
    public event Death OnDeath;

}
