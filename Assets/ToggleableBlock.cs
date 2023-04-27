using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
public class ToggleableBlock : ToggleableObstacle
{
    [SerializeField]
    Animator animator;

    void Awake()
    {

    }
    protected override void OnChange(bool value)
    {
        animator.SetBool("Up", value != invert);
    }
}
