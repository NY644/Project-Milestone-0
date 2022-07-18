using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIController : Controller
{

    public enum AIStates { Idle, Chase, Attack,
        Flee, ChooseTarget, Patrol };

    public AIStates currentState;

    public float timeEnteredCurrentState;

    public GameObject AITarget;

    public List<Transform> waypoints;

    public int currentWaypoint;

    //Data for senses
    public float hearingRadius;
    public float fieldOfView;
    public float viewDistance;

  
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

    public virtual void DoTargetNearestPlayerState()
    {
        AITarget = GetNearestPlayer();
    }

    public virtual GameObject GetNearestPlayer()
    {
        // Assume player 0 is closest
        GameObject nearestPlayer = GameManager.instance.players[0].pawn.gameObject;

        float nearestPlayerDistance = 
            Vector3.Distance(pawn.transform.position,
            GameManager.instance.players[0].pawn.transform.position);
      
        // Check the rest of the players to see if any of them are closer
        for (int index = 1; index < 
            GameManager.instance.players.Count; index++)
        {
            float tempDistance = Vector3.Distance
                (pawn.transform.position,
                GameManager.instance.players[index].
                pawn.transform.position);

            if (tempDistance < nearestPlayerDistance)
            {
                nearestPlayer = GameManager.instance.players[index].pawn.gameObject;
                nearestPlayerDistance = tempDistance;
            }

        }

        // When we get here, we've checked EVERY player and found the closest
        return nearestPlayer;

    }

    public virtual void Chase (Controller chaseTarget)
    {
        Chase(chaseTarget.pawn.gameObject);
    }

    public virtual void Chase (Transform chaseTarget)
    {
        Chase(chaseTarget.gameObject);
    }

    public virtual void Chase (Vector3 chaseTarget)
    {
       
        
            // Turn towards our target
            pawn.TurnTowards(chaseTarget);

            // Move forwards
            pawn.MoveForward();
        
    }

    public virtual void Chase(GameObject chaseTarget)
    {
        if (chaseTarget != null)
        {
            Chase(chaseTarget.transform.position);
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

    public virtual void DoPatrolState()
    {
        // Create a temp target location
        Vector3 tempTargetLocation = waypoints[currentWaypoint].position;

        // Adjust this temp location, so the y is the same y as my pawn
        tempTargetLocation = new Vector3(tempTargetLocation.x, pawn.transform.position.y,
            tempTargetLocation.z);

        // Move to my current waypoint
        Chase(tempTargetLocation);

        // If we are close enough to it,
        // then increment our current waypoint
        if (Vector3.Distance(pawn.transform.position, tempTargetLocation) <= 1 )
        {
            currentWaypoint++;
        }
        // If we get to the last waypoint ---
        if (currentWaypoint >= waypoints.Count)
        {
            // Go back to the first one.
            currentWaypoint = 0;
        }



    }

    public virtual bool IsCanSee (GameObject target)
    {
        // Check if in FoV
        Vector3 VectorToTarget = target.transform.position - pawn.transform.position;
        float angleToTarget = Vector3.Angle(pawn.transform.forward, VectorToTarget);

        if (angleToTarget > fieldOfView)
        {
            return false;
        }

        // Check if in LoS
        Ray tempRay = new Ray(pawn.transform.position, VectorToTarget);
        RaycastHit hitInfo;
        if (Physics.Raycast(tempRay, out hitInfo, viewDistance))
        {
            // Check if the thing we hit is our target
            if (hitInfo.collider.gameObject == target)
            {
                // Then we can see it -- there is nothing in the way!
                return true;
            }
        }
        // If we made it this far, something is in the way
        // or is too far away or we otherwise can't see it
        return false;
    }

    public virtual bool IsCanHear(GameObject target)
    {
        // Get noisemaker component
        NoiseMaker targetNoiseMaker = target.GetComponent<NoiseMaker>();
        // If it does not exist
        if (targetNoiseMaker == null)
        {


            // Then, we aren't making sound - return false
            return false;
        }

        else {
            // Else
            // Check if the distance between objects is less than the sum of the two radii
            float sumOfRadii = targetNoiseMaker.noiseDistance + hearingRadius;

            if (Vector3.Distance(target.transform.position,
                pawn.transform.position) <= sumOfRadii)
            {
                //  Then we can hear them
                return true;
            }

            else
            {
                //  else
                //  We can't hear them - return false
                return false;
            }
        }

    }
}
