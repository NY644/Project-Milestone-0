using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    // These help decide if an object can spawn
    public GameObject objectToSpawn;
    public float timeBetweenSpawns;
    public bool isSpawnedAtStart;
    private GameObject spawnedObject;
    private float spawnCountdown;

    // Start is called before the first frame update
    void Start()
    {
        // If object is allowed to spawn at start.
        // Set spawnCountdown to 0.
        if (isSpawnedAtStart)
        {
            spawnCountdown = 0;
        }

        else
        {
            // Creates a timer between item spawns
            spawnCountdown = timeBetweenSpawns;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // This section asks if the object already exists.
        // If not, then spawn the object.
        if (spawnedObject != null)
        {
            // An object exists, do nothing!
        }

        // else spawn the pickup if it's possbile
        else
        {
           
            spawnCountdown -= Time.deltaTime;

            // If spawnCountdown <= 0, spawn the object.
            if (spawnCountdown <= 0)
            {
               spawnedObject = Instantiate
                    (objectToSpawn,
                    transform.position,
                    transform.rotation);

                spawnCountdown = timeBetweenSpawns;
            }
        }
    }
}
