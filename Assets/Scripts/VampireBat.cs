using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class VampireBat : MonoBehaviour
{
    [SerializeField]Transform HomePoint;
    [SerializeField] Collider2D ViewArea;

    [SerializeField]AIDestinationSetter destinationSetter;
    [SerializeField]AIPath path;

    [SerializeField]float timeBeforeForgetting;

    [SerializeField]string TargetableTag;

    [SerializeField]Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(path.reachedDestination && destinationSetter.target == HomePoint)
        {
            path.isStopped = true;
            animator.SetBool("Flying", false);
        }
        else
        {
            path.isStopped = false;
            animator.SetBool("Flying", true);
        } 
    }

    void OnSeeObject(Collider2D other)
    {
        StopCoroutine(StopFollowingAfterTime(timeBeforeForgetting));
        Debug.Log(other.tag == TargetableTag);
        if(other.tag == TargetableTag) destinationSetter.target = other.transform;
    }

    void OnUnSeeObject(Collider2D other)
    {
        if(other.transform == destinationSetter.target) StartCoroutine(StopFollowingAfterTime(timeBeforeForgetting));
    }

    IEnumerator StopFollowingAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        destinationSetter.target = HomePoint;
    }
}
