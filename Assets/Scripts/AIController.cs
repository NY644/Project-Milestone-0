using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIController : Controller
{

    public enum AIStates { Idle, Chase, Attack,
        Flee, ChooseTarget };

    public AIStates currentState;

    public float timeEnteredCurrentState;

  
    public virtual void ChangeState(AIStates newState)
    {
        // Remember the time we changed states
        timeEnteredCurrentState = Time.time;
        // Change our state
        currentState = newState;
    }

    public virtual void DoIdleState()
    {
        // Do nothing
    }

    public virtual void DoChaseState()
    {
        // TODO: Add a max speed to pawns,
        // and set this AI's speed to max speed

        // Do the chase action!
    }

    public virtual void DoAttackState()
    {
        // Chase the player (action)
        // Shoot (action)
    }

    public virtual void Chase(GameObject chaseTarget)
    {
        // Turn towards our target
        pawn.TurnTowards(chaseTarget.transform.position);
        // Move forwards
        pawn.MoveForward();

    }
}
