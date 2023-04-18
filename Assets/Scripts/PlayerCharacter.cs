using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerCharacter : MonoBehaviour
{
    [SerializeField]Animator animator;

    Vector2 Direction;

    [SerializeField]
    float Speed;

    InputActionMap actions;

    // Start is called before the first frame update
    void Start()
    {
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
        transform.Translate(Direction*Time.deltaTime*Speed, Space.World);   
    }

    void GetDirection(InputAction.CallbackContext context)
    {
        if(context.canceled)
        {
            Direction = Vector2.zero;
            animator.SetBool("Walking", false);
        }
        else{
            Direction = context.ReadValue<Vector2>();
            animator.SetInteger("Direction", Vector2ToDirectionInt(Direction));
            animator.SetBool("Walking", true);
        }
    }

    int Vector2ToDirectionInt(Vector2 input)
    {

        bool DominantX = Mathf.Abs(input.x) > Mathf.Abs(input.y);
        if(DominantX)
        {
            if(input.x > 0) return 1;
            else return 3;
        }
        else
        {
            if(input.y > 0) return 0;
            else return 2;
        }
    }



}
