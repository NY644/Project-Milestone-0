using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TankPawn : Pawn
{
    public TankMover mover;
    public Shooter shooter;

    public GameObject bulletPrefab;
    public GameObject bigBulletPrefab;
    public float damageDone;
    public float bigDamageDone;
    public float bigShootForce;
    public float shootForce;

    public AudioClip TankFire;
    public AudioClip BigTankFire;
    public AudioSource speaker;

    // private float nextShootTime;
    private float countdown;

    public float bigTimeBetweenShots;
    public float timeBetweenShots;
    // Start is called before the first frame update
    public override void Start()
    {
        mover = GetComponent<TankMover>();
        shooter = GetComponent<Shooter>();

        // Set our countdown
        countdown = timeBetweenShots;
    }

    // Update is called once per frame
    public override void Update()
    {
        // Decrease our countdown by how much time has passed since the last update
        countdown = countdown - Time.deltaTime;
    }

    public override void Shoot()
    {
        
        // Check if countdown is <= 0
        if (countdown <= 0)
        {
            // If yes, then shoot
            shooter.Shoot(bulletPrefab, shootForce,
                damageDone, this);
            speaker.PlayOneShot(TankFire);

            // Reset countdown
            countdown = timeBetweenShots;

           
        }
    }

    public override void BigShoot()
    {
        // Check if countdown is <= 0
        if (countdown <= 0)
        {
            // If yes, then shoot
            shooter.Shoot(bigBulletPrefab, bigShootForce,
                bigDamageDone, this);
            speaker.PlayOneShot(BigTankFire);

            // Reset countdown
            countdown = bigTimeBetweenShots;


        }

    }

    public override void MoveForward()
    {
        mover.MoveForward(moveSpeed);
        base.MoveForward();
    }

    public override void MoveBackward()
    {
        mover.MoveForward(-moveSpeed);
        base.MoveBackward();
    }

    public override void TurnRight()
    {
        mover.Turn(turnSpeed);
        base.TurnRight();
    }

    public override void TurnLeft()
    {
        mover.Turn(-turnSpeed);
        base.TurnLeft();
    }

    public override void TurnTowards(Vector3 targetPosition)
    {
        // Find the vector to our target position from our position
        Vector3 vectorToTargetPosition = targetPosition - transform.position;

        // Find the quaternion needed to look down that vector
        Quaternion look = Quaternion.LookRotation(vectorToTargetPosition, transform.up);

        // Change our rotation to be sligthly down that quaternion
        transform.rotation = Quaternion.RotateTowards(transform.rotation, 
            look, turnSpeed);

    }
}
