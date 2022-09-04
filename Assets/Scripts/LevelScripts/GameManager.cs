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

    // These help the tank choose one of the spawnpoints
    public TankSpawn[] spawn;
    private Transform playerSpawnTransform;

    // prefabs
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;

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

    // Audio mixer used for audio
    public AudioMixer audioMixer;
    public AudioSource speaker;
    public AudioClip ButtonClicked;

    // Generates the rooms for the map randomly
    public LevelGenerator roomGen;

    public int lives;


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

    void Start()
    {
        ActivateTitleScreenState();

        // Lives are set to 4 because once
        // the game starts, a player tank is spawned.
        // this means lives is subtracted by 1.
        // So the player actually starts with 3 lives.
        lives = 4;
       
    }

    // Update is called once per frame
    void Update()
    {
      

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

        // Switches to game over screen and then resets lives to 4
        if (lives == 0)
        {
            ActivateGameOverScreenState();
            lives = 4;
        }
    }

    // Function that spawns the player at a random
    // spawnpoint and gives them their controller.
    public void SpawnPlayer()
    {
        // Chooses one of the random spawnpoints.
        setPlayerSpawn();

        // Spawn playerController at origin with no rotation
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, 
            Vector3.zero, Quaternion.identity) as GameObject;

        // spawn the pawn and connect it to the controller
        GameObject newPawnObj = Instantiate
            (tankPawnPrefab, playerSpawnTransform.position,
            playerSpawnTransform.rotation) as GameObject;

        // get the playerController component and the pawn component
        KeyboardController newController = 
            newPlayerObj.GetComponent<KeyboardController>();

        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        // connect the new objects
        newController.pawn = newPawn;
        newPawn.controller = newController;

        // Every time this function is called, lives are
        // subtracted by 1.
        lives = lives - 1;
        Debug.Log("You have " + lives + " lives remaining");
    }

   

    // Press R to spawn AI Tank
    public void SpawnAI()
    {
        // Chooses a random spawnpoint for the AI.
        setPlayerSpawn();

        GameObject newController = new GameObject();

        AIController_Simple AI_Tank = newController.AddComponent<AIController_Simple>();

        // Places the AI tank pawn at the chosen random spawnpoint.
        GameObject newPawn = Instantiate(tankPawnPrefab, playerSpawnTransform.position,
            playerSpawnTransform.rotation) as GameObject;

        Pawn newPawnScript = newPawn.GetComponent<Pawn>();

        // Connects the controller and the pawn together.
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
        gameOverScreenStateObject.SetActive(false);
        gamePlayStateObject.SetActive(false);
    }

    // Puts game in main menu state
    public void ActivateMainMenuState()
    {
        DeactivateAllStates();
        speaker.PlayOneShot(ButtonClicked);
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

        // Randomly generates the levels.
        roomGen.GenerateLevel();

       
        // Finds objects called tank spawns
        spawn = FindObjectsOfType<TankSpawn>();

        // Spawns the AI
        SpawnAI();

        // Spawns the Player
        SpawnPlayer();
     
        // If One Player, set a camera for one player
        // If two player, set/create? cameras for two player
    }

    public void ActivateGameOverScreenState()
    {
        DeactivateAllStates();
        gameOverScreenStateObject.SetActive(true);
    }

    public void ActivateOptionsScreenState()
    {
        DeactivateAllStates();
        optionsScreenStateObject.SetActive(true);
    }
}
