using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CharVar;
public class HealthTrackingKillable : Killable
{
    public Health trackable;
    // Start is called before the first frame update
    void Start()
    {
        trackable.OnHealthChange += OnChange;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnChange(int amount)
    {
        dead = amount <= 0;
    }
}
