using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigShooter : MonoBehaviour
{
    public Transform shootPoint;
    public void Shoot(GameObject bigBulletprefab, float shootForce,
        float damageDone, Pawn shooter)
    {
        // Create the bullet
        GameObject theBullet = Instantiate(bigBulletprefab,
            shootPoint.position, transform.rotation);

        // Give it the data it needs
        Projectile projectile = theBullet.GetComponent<Projectile>();

        if (projectile != null)
        {
            projectile.damageDone = damageDone;
            projectile.owner = shooter;
            // Put shoot sound effect here.
        }


        // Push it
        Rigidbody bulletRb = theBullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.AddForce(transform.forward * shootForce);
        }

        // Destory the bullet after 5 seconds
        Destroy(theBullet, 5);
    }
}

