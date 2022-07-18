using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    // We want designers to be able to change the type of map
    public enum MapType { Random, MapOfTheDay, Seed };
    public MapType type;

    // Store our level after it's been created
    public Room[,] grid;

    // List of all rooms we could choose from
    public List<Room> possibleRooms;

    // Data about our map
    private float roomWidth = 50.0f;
    private float roomHeight = 50.0f;

    // allows the designer to choose
    // how many columns and rows they want the map to have.
    public int numberOfRows;
    public int numberOfCols;

    // The seed is a code that can be entered
    // by players to allow them to all have
    // easy access to the same randomly generated map.
    public int randomSeed;




    // Start is called before the first frame update
    void Start()
    {
        // Setup our grid 2D array
        grid = new Room[numberOfCols, numberOfRows];
    }


    public void GenerateLevel()
    {
        // This if statement will create the map.
        // Seed the RNG based on our designer choice
        if (type == MapType.Random)
        {
            // Seed the RNG with a random number!

            Random.InitState
                ((int)System.DateTime.Now.Ticks);
        }

        // This else if will associate the code with the map made.
        else if (type == MapType.Seed)
        {
            // Seed the RNG with our seed value
            Random.InitState(randomSeed);
        }

        // This else will declare the seed with the map for the day.
        else
        {
            // Seed the RNG for Map of the Day
            Random.InitState((int)System.DateTime.Today.Ticks);
        }

        // Clear/Reset our grid 2D array
        grid = new Room[numberOfCols, numberOfRows];

        // One row at a time
        for (int currentRow = 0;
            currentRow < numberOfRows; currentRow++)
        {


            // One col at a time
            for (int currentCol = 0;
                currentCol < numberOfCols; currentCol++)
            {
                // Instantiate a random room
                Room newRoom = Instantiate(GetNextRoom()) as Room;
                // Move it to the correct position
                Vector3 newPosition = new Vector3
                    (currentCol * roomWidth, 0.0f,
                    currentRow * roomHeight);

                newRoom.transform.position = newPosition;
                // Give it a meaningful name
                newRoom.gameObject.name = "Room("
                    + currentCol + "," + currentRow + ")";
                // TODO: Organize our Hierarchy
                newRoom.gameObject.transform.parent = this.transform;
                // Save it to the grid
                grid[currentCol, currentRow] = newRoom;

                // Open the correct doors
                // If it is possible, these if statements will
                // delete the doors to allow players to access
                // a nearby room. Otherwise, the door will
                // remain existing.
                if (currentRow != 0)
                {
                    newRoom.doorSouth.SetActive(false);
                }

                if (currentRow != numberOfRows - 1)
                {
                    newRoom.doorNorth.SetActive(false);
                }

                if (currentCol != 0)
                {
                    newRoom.doorWest.SetActive(false);
                }

                if (currentCol != numberOfCols - 1)
                {
                    newRoom.doorEast.SetActive(false);
                }

            }

        }

    }

    // If the program is allowed to generate the next room
    // by the desginer, then this function will be used
    // to create the next room.
    public Room GetNextRoom()
    {
        // For now, this just returns a random room
        return possibleRooms[Random.Range(0,
            possibleRooms.Count)];
    }

    
}
