using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<KeyboardController> players;
    public List<KeyboardController> AI;
    public GameObject pawnPrefab;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnPlayer(0);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnAI();
        }
    }

    // Press P to spawn player Tank
    public void SpawnPlayer(int playerNumber)
    {
       GameObject newPawn = Instantiate(pawnPrefab, Vector3.zero,
           Quaternion.identity);
        Pawn newPawnScript = newPawn.GetComponent<Pawn>();
        if (newPawnScript != null)
        {
            if (players.Count > playerNumber)
            {
                players[playerNumber].pawn = newPawnScript;
            }
        }
    }

    // Press R to spawn AI Tank
    public void SpawnAI()
    {
        GameObject newController = new GameObject();

        AIController_Simple AI_Tank = newController.AddComponent<AIController_Simple>();

        GameObject newPawn = Instantiate(pawnPrefab, Vector3.zero,
           Quaternion.identity);

        Pawn newPawnScript = newPawn.GetComponent<Pawn>();

        AI_Tank.pawn = newPawnScript;

        
    }
}
