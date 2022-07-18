using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<KeyboardController> players;
    public List<KeyboardController> AI;
    public GameObject pawnPrefab;

    [Header("State Screen Objects")]
    public GameObject titleScreenStateObject;
    public GameObject mainMenuScreenStateObject;
    public GameObject gamePlayStateObject;
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
                LinkPawnAndController(newPawnScript, players[playerNumber]);
            }
        }
    }

    // Links player controller with spawned tanks.
    public void LinkPawnAndController( Pawn pawn, Controller controller)
    {
        controller.pawn = pawn;
        pawn.controller = controller;
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

    private void DeactivateAllStates()
    {
        titleScreenStateObject.SetActive(false);
        mainMenuScreenStateObject.SetActive(false);
    }

    public void ActivateMainMenuState()
    {
        DeactivateAllStates();
        mainMenuScreenStateObject.SetActive(true);
    }

    public void ActivateTitleScreenState()
    {
        DeactivateAllStates();
        titleScreenStateObject.SetActive(true);
    }

    public void ActivateGameplayState()
    {
        DeactivateAllStates();
        gamePlayStateObject.SetActive(true);
        // TODO: Generate my map
        // TODO: Spawn my player controller(s)
        // TODO: Spawn the player pawn(s)

    }
}
