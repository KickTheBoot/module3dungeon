using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class VampireBat : Character
{
    [SerializeField]Transform homePoint;
    [SerializeField]Collider2D viewArea;
    [SerializeField]protected AIDestinationSetter destinationSetter;
    [SerializeField]protected AIPath path;

    [SerializeField]protected float timeBeforeForgetting;
    protected float elapsedTime;

    [SerializeField]string targetableTag;

    [SerializeField]protected Animator animator;

    StateMachine stateMachine;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Flying", false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(path.reachedDestination && destinationSetter.target == homePoint)
        {
            path.isStopped = true;
            animator.SetBool("Flying", false);
        }
        else
        {
            path.isStopped = false;
            animator.SetBool("Flying", true);
        } 

        if(elapsedTime >= timeBeforeForgetting) destinationSetter.target = homePoint;
        elapsedTime += Time.deltaTime;
    }

    void OnSeeObject(Collider2D other)
    {
        Debug.Log(other.tag == targetableTag);
        if(other.tag == targetableTag) destinationSetter.target = other.transform;
    }

    void OnUnSeeObject(Collider2D other)
    {
    }

    void OnObjectInSight(Collider2D other)
    {
        if(other.tag == targetableTag) elapsedTime = 0;
    }

    void OnHit(HurtBox Other)
    {
        health.Damage(Other.Damage);
    }


    public override void OnDeath()
    {
        Destroy(gameObject);
    }

    
}
