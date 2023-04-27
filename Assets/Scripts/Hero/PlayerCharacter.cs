using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using CharVar;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerCharacter : Character
{
    static PlayerCharacter instance;

    public GameObject Weapon;
    
    public StateMachine stateMachine;

    public Animator animator;

    public Rigidbody2D rb;
    public Vector2 direction;
    public Vector2 facing;

    public int KeyCount;

    [SerializeField]
    public float speed;

    InputActionMap actions;

    InputAction attack;

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else 
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new Idle(this));
        rb = GetComponent<Rigidbody2D>();
        actions = GameManager.instance.GetInputActions().FindActionMap("Hero");
        Debug.Log(actions);
        actions.Enable();
        attack = actions.FindAction("Attack");
        actions.FindAction("Move").performed += GetDirection;
        actions.FindAction("Move").canceled += GetDirection;
        actions.FindAction("Move").Enable();
    }

    void OnDisable()
    {
        if(actions != null)
        {
        actions.FindAction("Move").performed -= GetDirection;
        actions.FindAction("Move").canceled -= GetDirection;
        }
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    void GetDirection(InputAction.CallbackContext context)
    {
        if(context.canceled)
        {
            direction = Vector2.zero;
        }
        else{

            direction = Vector2.ClampMagnitude(context.ReadValue<Vector2>(),1);
            facing = direction.normalized;
            animator.SetFloat("DirX", direction.x);
            animator.SetFloat("DirY", direction.y);
        }
    }

    public Vector2 GetCharacterSpeed()
    {
        return direction;
    }

    public void OnHit(HurtBox other)
    {
        Debug.Log($"Take {other.Damage} damage!");
        rb.AddForce((transform.position - other.transform.position).normalized * other.knockBackForce,ForceMode2D.Impulse);
    }


    class Idle : IState
    {
        PlayerCharacter Character;
        public Idle(PlayerCharacter character)
        {
            this.Character = character;
        }
        
        public void Enter()
        {
            Debug.Log("Entered Idle State");
        }

        public void Update()
        {
            if(Character.attack.WasPressedThisFrame())Character.stateMachine.ChangeState(new Attack(this.Character));
            if(Character.direction.magnitude > 0.1f) Character.stateMachine.ChangeState(new Walking(this.Character));
        }

        public void FixedUpdate()
        {

        }

        public void Exit()
        {
            Debug.Log("Exited Idle State");
        }
    }

    class Walking : IState
    {
        PlayerCharacter Character;
        public Walking(PlayerCharacter character)
        {
            this.Character = character;
        }
        public void Enter()
        {
            Debug.Log("Entered Walking State");
            this.Character.animator.SetBool("Walking", true);
        }

        public void Update()
        {
            if(Character.attack.WasPerformedThisFrame())Character.stateMachine.ChangeState(new Attack(this.Character));
            

            if(Character.direction.magnitude < 0.1f) Character.stateMachine.ChangeState(new Idle(this.Character));
        }

        public void FixedUpdate()
        {
            Character.rb.MovePosition(Character.rb.position + Character.direction*Time.fixedDeltaTime*Character.speed);
        }

        public void Exit()
        {
            Debug.Log("Exited Walking State");
            this.Character.animator.SetBool("Walking", false);
        }
    }

    class Attack : IState
    {
        PlayerCharacter Character;

        float time = 0.2f;
        float elapsedTime = 0;
        public Attack(PlayerCharacter character)
        {
            this.Character = character;
        }

        public void Enter()
        {
            Debug.Log("Entering Attack State");
            elapsedTime = 0;
            Character.animator.SetTrigger("Dagger");
            Ray ray = new Ray(Character.transform.position,Character.facing);
            
                GameObject.Instantiate(Character.Weapon,ray.origin + ray.direction, Quaternion.LookRotation(Vector3.back, ray.direction));
            
        }
        
        public void Update()
        {
            if(elapsedTime >= time) Character.stateMachine.ChangeState(new Idle(Character));
            elapsedTime += Time.deltaTime;
        }

        public void FixedUpdate()
        {

        }

        public void Exit()
        {
            Debug.Log("Exiting Attack State");
        }
    }
}

