// Object: Doorways
// Purpose: Move the player to the opposite doorway once they hit a doorway

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapCamera : MonoBehaviour
{
    private GameObject playerObject;
    private GameObject enemySpawner;
    private Vector3 doorwayPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
        enemySpawner = GameObject.Find("EnemySpawner");
        doorwayPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject == GameObject.Find("DoorwayL"))
            {
                Vector3 enterPosition = new Vector3(-doorwayPosition.x - 0.5f, playerObject.transform.position.y, 0);
                playerObject.transform.position = Vector3.MoveTowards(playerObject.transform.position, enterPosition, 10);
            }
            else if (gameObject == GameObject.Find("DoorwayR"))
            {
                Vector3 enterPosition = new Vector3(-doorwayPosition.x + 0.5f, playerObject.transform.position.y, 0);
                playerObject.transform.position = Vector3.MoveTowards(playerObject.transform.position, enterPosition, 10);
            }
            else if (gameObject == GameObject.Find("DoorwayT"))
            {
                Vector3 enterPosition = new Vector3(0, playerObject.transform.position.y, -doorwayPosition.z + 0.5f);
                playerObject.transform.position = Vector3.MoveTowards(playerObject.transform.position, enterPosition, 10);
            }
            else if (gameObject == GameObject.Find("DoorwayB"))
            {
                Vector3 enterPosition = new Vector3(0, playerObject.transform.position.y, -doorwayPosition.z - 0.5f);
                playerObject.transform.position = Vector3.MoveTowards(playerObject.transform.position, enterPosition, 10);
            }
            enemySpawner.GetComponent<EnemySpawner>().OnTriggerEnter(other);
        }
    }
}
