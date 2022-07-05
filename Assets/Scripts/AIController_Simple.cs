using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController_Simple : AIController
{
    // Start is called before the first frame update
    public override void Start()
    {
        // starts in the Idle state
        ChangeState(AIStates.Idle);

        // TODO: This AI targets player one
       // AITarget = GameManager.instance.players[0].pawn.gameObject;
    }

    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions();
    }

    

    public override void MakeDecisions()
    {
        // Finite State Machine
        // Based on our current state
        switch (currentState)
        {
            case AIStates.Idle:
                // Do work
                DoIdleState();
                // Check for conditions
                if (IsTimePassed(3))
                {
                    ChangeState(AIStates.Patrol);
                }
                break;

            case AIStates.Patrol:
                DoPatrolState();
                // Check for Conditions
                // Stay in patrol FOREVER...
                break;

            case AIStates.Chase:
                // Do work
                DoChaseState();
                // Check for conditions
                if (IsTimePassed(1))
                {
                    ChangeState(AIStates.Idle);
                }
                break;

            case AIStates.ChooseTarget:
                DoChangeTargetState();
                // No conditions, always change
                ChangeState(AIStates.Chase);
                break;
        }
    }
}
