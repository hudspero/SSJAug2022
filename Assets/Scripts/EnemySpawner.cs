// Object: EnemySpawner
// Purpose: Spawns enemies only when the player enters the room

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject playerObject;
    private Collider collider;
    public GameObject doorwayBlockerPrefab;
    public GameObject[] enemies;
    public bool isCombat;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("EnemyD(Clone)") && !GameObject.Find("EnemyN(Clone)"))
        {
            Destroy(GameObject.Find("DoorwayBlocker(Clone)"));
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            int roomType = (int)Random.Range(1, 10);
            if (roomType % 2 == 0)
            {
                Debug.Log("Puzzle Room");
            }
            else
            {
                Debug.Log("Combat Room");
                SpawnEnemies();                
            }
        }
    }

    // Spawn a random number of enemies within the Box Collider bounds in that specific spawn grid
    void SpawnEnemies()
    {
        Instantiate(doorwayBlockerPrefab, transform.position, doorwayBlockerPrefab.transform.rotation);
        int numEnemies = (int)Random.Range(2, 6);
        for (int i=0; i<numEnemies; i++)
        {
            int enemyType = (int)Random.Range(1, 10); // Odd = EnemyD, Even = EnemyN
            float xPos = Random.Range(collider.bounds.min.x, collider.bounds.max.x);
            float zPos = Random.Range(collider.bounds.min.z, collider.bounds.max.z);
            Vector3 spawnPos = new Vector3(xPos, 0.25f, zPos);
            
            // Update the spawnBox variable to include which room the enemies were spawned in
            if (enemyType % 2 != 0) // If odd, spawn EnemyD
            {
                GameObject enemy = Instantiate(enemies[0], spawnPos, enemies[0].transform.rotation);
                enemy.GetComponent<EnemyDController>().spawnBox = gameObject;
            }
            else // Else, spawn EnemyN
            {
                GameObject enemy = Instantiate(enemies[1], spawnPos, enemies[1].transform.rotation);
                enemy.GetComponent<EnemyNController>().spawnBox = gameObject;
            }
        }
    }
}
