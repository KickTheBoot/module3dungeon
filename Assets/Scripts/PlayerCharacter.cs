using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]Animator animator;

    Rigidbody2D rb;
    Vector2 Direction;

    [SerializeField]
    float Speed;

    InputActionMap actions;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        actions = GameManager.instance.GetInputActions().FindActionMap("Hero");
        Debug.Log(actions);
        actions.Enable();
        actions.FindAction("Move").performed += GetDirection;
        actions.FindAction("Move").canceled += GetDirection;
        actions.FindAction("Move").Enable();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Direction*Time.fixedDeltaTime*Speed);
    }

    void GetDirection(InputAction.CallbackContext context)
    {
        if(context.canceled)
        {
            Direction = Vector2.zero;
            animator.SetBool("Walking", false);
        }
        else{
            Direction = Vector2.ClampMagnitude(context.ReadValue<Vector2>(),1);
            animator.SetFloat("DirX", Direction.x);
            animator.SetFloat("DirY", Direction.y);
            animator.SetBool("Walking", true);
        }
    }
}
