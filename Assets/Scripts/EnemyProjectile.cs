// Object: EnemyProjectile
// Purpose: Control projectile movement based on player position when it first spawns

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private GameObject playerObject;
    private Vector3 translatePos;
    private float projectileSpeed = 0.012f;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
        translatePos = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, playerObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the projectile to the stored player coordinates
        transform.position = Vector3.MoveTowards(transform.position, translatePos, projectileSpeed);
        if (transform.position == translatePos)
        {
            Destroy(gameObject);
        }
    }
}
