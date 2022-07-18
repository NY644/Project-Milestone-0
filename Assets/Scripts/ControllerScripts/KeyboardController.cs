using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : Controller
{
    [Header("Control Key Codes")]
    public KeyCode moveForward;
    public KeyCode moveBackward;
    public KeyCode turnRight;
    public KeyCode turnLeft;
    public KeyCode shoot;
    public KeyCode bigShoot;

    

    // Start is called before the first frame update
    public override void Start()
    {
        // Add myself to the list of players
        GameManager.instance.players.Add(this);
        
    }

    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions();
    }

    public override void AddToScore (int pointsToAdd)
    {
        // Add to my score
        score = score + pointsToAdd;

    }

    public void OnDestroy()
    {
        // Remove myself from the list of players
        GameManager.instance.players.Remove(this);
    }

    public override void MakeDecisions()
    {
        if (Input.GetKey(moveForward))
        {
            pawn.MoveForward();
            Debug.Log("Forward");
        }

        if (Input.GetKey(moveBackward))
        {
            pawn.MoveBackward();
            Debug.Log("Backward");
        }

        if (Input.GetKey(turnLeft))
        {
            pawn.TurnLeft();
            Debug.Log("Turn Left");
        }

        if (Input.GetKey(turnRight))
        {
            pawn.TurnRight();
            Debug.Log("Turn Right!");
        }

        if (Input.GetKeyDown(shoot))
        {
            pawn.Shoot();
            Debug.Log("Shooting!");
        }

        if (Input.GetKey(bigShoot))
        {
            pawn.BigShoot();
            Debug.Log("Big Shoot!");
        }
    }
}
