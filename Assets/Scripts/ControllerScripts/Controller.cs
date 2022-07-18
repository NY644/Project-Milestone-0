using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{

    public Pawn pawn;
    [Header("Player Data")]
    public int score;
    public int lives;

    // Start is called before the first frame update
    public abstract void Start();




    // Update is called once per frame
    public abstract void Update();


    public abstract void MakeDecisions();

    public abstract void AddToScore(int pointsToAdd);
    

    

    
}
