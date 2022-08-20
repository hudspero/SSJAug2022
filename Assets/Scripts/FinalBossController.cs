// Object: Final Boss
// Purpose: Control the Final Boss and attack the player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossController : MonoBehaviour
{
    public GameObject spawnBox;
    public GameObject enemyProjectilePrefab;
    private GameObject playerObject;

    private Vector3 enemyMove;
    private float enemyBoundX = 4.9f;
    private float enemyBoundZ = 4.9f;
    private float enemySpeed = 2.0f;
    private float moveInterval = 0.75f;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Move", 0.25f, moveInterval);
        health = 20;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, enemyMove, enemySpeed * Time.deltaTime);
    }

    // Pick a random point within the spawnBox (and only the spawnBox) to move around in
    private void Move()
    {
        float randX = Random.Range(spawnBox.transform.position.x - enemyBoundX, spawnBox.transform.position.x + enemyBoundX);
        float randZ = Random.Range(spawnBox.transform.position.z - enemyBoundZ, spawnBox.transform.position.z + enemyBoundZ);
        enemyMove = new Vector3(randX, 0.15f, randZ);
        playerObject = GameObject.Find("Player");
        if (playerObject)
        {
            Instantiate(enemyProjectilePrefab, transform.position, enemyProjectilePrefab.transform.rotation);
        }
    }
}
