using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<KeyboardController> players;
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
    }

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
}
