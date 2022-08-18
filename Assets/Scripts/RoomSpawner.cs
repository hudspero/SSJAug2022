// Object: SpawnPoint_ for every Room Prefab
// Purpose: Spawn a room at that specific point

// Code liberally borrows from Blackthornprod on YouTube:
// Part 1 - https://www.youtube.com/watch?v=qAf9axsyijY
// Part 2 - https://www.youtube.com/watch?v=eR74EjkA_4s
// Part 3 - https://www.youtube.com/watch?v=CUdKdHmT8xA

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection; // Determines which way to spawn rooms (if doors are available)
    private int rand;
    private bool spawned = false;
    private RoomTemplates roomTemplates;

    // Start is called before the first frame update
    void Start()
    {
        // Get the GameObject arrays of rooms stored in the RoomTemplates script within the Room Templates GameObject
        Destroy(gameObject, 4.0f);
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    // Spawn the rooms
    void Spawn()
    {
        if (spawned == false) 
        {
            if (openingDirection == 0) // Spawn B-related room
            {
                rand = Random.Range(0, roomTemplates.bottomRooms.Length); // Gets index of array to grab room prefab from
                Instantiate(roomTemplates.bottomRooms[rand], transform.position, roomTemplates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 1) // Spawn T-related room
            {
                rand = Random.Range(0, roomTemplates.topRooms.Length); // Gets index of array to grab room prefab from
                Instantiate(roomTemplates.topRooms[rand], transform.position, roomTemplates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2) // Spawn L-related room
            {
                rand = Random.Range(0, roomTemplates.leftRooms.Length); // Gets index of array to grab room prefab from
                Instantiate(roomTemplates.leftRooms[rand], transform.position, roomTemplates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3) // Spawn R-related room
            {
                rand = Random.Range(0, roomTemplates.rightRooms.Length); // Gets index of array to grab room prefab from 
                Instantiate(roomTemplates.rightRooms[rand], transform.position, roomTemplates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }

    // If a spawned room collides with the Box Collider component of the SpawnPoint, destroy the SpawnPoint
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
