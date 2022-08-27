using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
// Might need to add using UnityEngine.UI

public class GameManager : MonoBehaviour
{
    // These help associate players and AI with tanks.
    public static GameManager instance;
    public List<KeyboardController> players;
    public List<KeyboardController> AI;
    public GameObject pawnPrefab;
    public TankSpawn[] spawn;
    private Transform playerSpawnTransform;

    // These are different states the game can be in.
    [Header("State Screen Objects")]
    public GameObject titleScreenStateObject;
    public GameObject mainMenuScreenStateObject;
    public GameObject gamePlayStateObject;
    public GameObject optionsScreenStateObject;
    public GameObject gameOverScreenStateObject;

    [Header("Game Options")]
    public int numberOfPlayers;
    public bool isMapOfTheDay;
    public float sfxVolume;
    public float musicVolume;

    public AudioMixer audioMixer;

    public LevelGenerator roomGen;

    // Variables for Keyboard controllers
    public KeyboardController WASDprefab;
    public KeyboardController Arrowprefab;

    // Test variables
    public GameObject[] spawnLocations;
    public GameObject player;

    private Vector3 respawnLocation;

    // Start is called before the first frame update

   void Start()
    {
        ActivateTitleScreenState();
    }

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
       // GameManager.instance.audioMixer.SetFloat("MusicVolume", 1.0f);

        // Press P to spawn player
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnPlayer();
        }

        // Press R to spawn AI
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnAI();
        }
    }

    

    

    // Press P to spawn player Tank
    public void SpawnPlayer()
    {
        // Test code
        //int spawn = Random.Range(0, spawnLocations.Length);
        //GameObject.Instantiate(player, spawnLocations[spawn].transform.position, Quaternion.identity);

        setPlayerSpawn();

        // Second Test zone

        // Spawn playerController at origin with no rotation
        GameObject newPlayerObj = Instantiate(player, 
            Vector3.zero, Quaternion.identity) as GameObject;

        // spawn the pawn and connect it to the controller
        GameObject newPawnObj = Instantiate
            (pawnPrefab, playerSpawnTransform.position,
            playerSpawnTransform.rotation) as GameObject;

        // get the playerController component and the pawn component
        KeyboardController newController = 
            newPlayerObj.GetComponent<KeyboardController>();

        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        // connect the new objects
        newController.pawn = newPawn;
        newPawn.controller = newController;

        //Vector3 randomSpawnPosition = tankSpawns[Random.Range(0, tankSpawns.Count)].transform.position;

        //GameObject newPawn = Instantiate(pawnPrefab, randomSpawnPosition,
        //    Quaternion.identity);
        //Pawn newPawnScript = newPawn.GetComponent<Pawn>();
        //if (newPawnScript != null)
        //{
        //    if (players.Count > playerNumber)
        //    {
        //        LinkPawnAndController(newPawnScript, players[playerNumber]);
        //    }
        //}
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

    public void setPlayerSpawn()
    {
        int temp = Random.Range(0, spawn.Length);
        playerSpawnTransform = spawn[temp].GetComponent<Transform>();
    }

    // Deactivate all non gameplay states
    private void DeactivateAllStates()
    {
        titleScreenStateObject.SetActive(false);
        mainMenuScreenStateObject.SetActive(false);
        optionsScreenStateObject.SetActive(false);
    }

    // Puts game in main menu state
    public void ActivateMainMenuState()
    {
        DeactivateAllStates();
        mainMenuScreenStateObject.SetActive(true);
    }

    // Puts game in Title Screen state
    public void ActivateTitleScreenState()
    {
        DeactivateAllStates();
        titleScreenStateObject.SetActive(true);
    }

    // Disables non gameplay states and begins gameplay.
    public void ActivateGameplayState()
    {
        DeactivateAllStates();
        gamePlayStateObject.SetActive(true);

        
        roomGen.GenerateLevel();

        //spawnLocations = GameObject.FindGameObjectsWithTag("SpawnPoint");

        //player = (GameObject)Resources.Load("UATank", typeof(GameObject));

        //respawnLocation = player.transform.position;

        spawn = FindObjectsOfType<TankSpawn>();
        
        // TODO: 1 Spawn my player controller(s)
        KeyboardController player1 = Instantiate(WASDprefab);
        // TODO: Spawn the player pawn(s)
        SpawnPlayer();
        // TODO: Spawn the enemies
        // TODO: Make sure scores set to 0
        player1.score = 0;
        // If One Player, set a camera for one player
        // If two player, set/create? cameras for two player
    }

    public bool IsGameOver()
    {
        //TODO: Write this later
        return false;
    }

    public void ActivateOptionsScreenState()
    {
        DeactivateAllStates();
        optionsScreenStateObject.SetActive(true);
    }
}
