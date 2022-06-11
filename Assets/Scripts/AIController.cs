using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIController : Controller
{

    public enum AIStates { Idle, Chase, Attack,
        Flee, ChooseTarget };

    public AIStates currentState;

    public float timeEnteredCurrentState;

    public GameObject AITarget;

  
    public virtual void ChangeState(AIStates newState)
    {
        // Remember the time we changed states
        timeEnteredCurrentState = Time.time;
        // Change our state
        currentState = newState;

        Debug.Log("Changed state to" + newState.ToString());
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
        Chase(AITarget);
    }

    public virtual void DoChangeTargetState()
    {
        AITarget = GameManager.instance.players[0].pawn.gameObject;
    }

    public virtual void DoAttackState()
    {
        // Chase the player (action)
        // Shoot (action)
    }

    public virtual void Chase(GameObject chaseTarget)
    {
        if (chaseTarget != null)
        {
            // Turn towards our target
            pawn.TurnTowards(chaseTarget.transform.position);

            // Move forwards
            pawn.MoveForward();
        }

        else
        {
            Debug.Log("Chase was passed a null target.");
        }

    }

    public virtual bool IsTimePassed(float amountOfTime)
    {
        if (Time.time - timeEnteredCurrentState >= amountOfTime)
        {
            return true;
        }

        return false;
    }
}
