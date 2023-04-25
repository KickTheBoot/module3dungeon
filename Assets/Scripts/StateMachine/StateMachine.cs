using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    IState State;
    public void ChangeState(IState State)
    {
        if(this.State != null)
        {
            this.State.Exit();
        }

        this.State = State;

        this.State.Enter();

    }
    public void Update()
    {
        if(State != null)
        {
            State.Update();
        }
        else Debug.LogWarning("No active state!");
    }

    public void FixedUpdate()
    {
        if(State != null)
        {
            State.FixedUpdate();
        }
        else Debug.LogWarning("No active state!");
    }
}

public interface IState
{
    void Enter();
    void Update();

    void FixedUpdate();
    void Exit();
}
