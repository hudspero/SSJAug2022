// Object: Projectile
// Purpose: Control projectile movement based on mouseTarget position (calculated in MousePosition.cs)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private GameObject mouseTarget;
    private GameObject playerObject;
    private Vector3 translatePos;
    private float projectileSpeed = 0.012f;

    // Start is called before the first frame update
    void Start()
    {
        // Find where the MouseTarget object is located when the projectile spawns
        mouseTarget = GameObject.Find("MouseTarget");
        playerObject = GameObject.Find("Player");
        translatePos = new Vector3(mouseTarget.transform.position.x, playerObject.transform.position.y, mouseTarget.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // Move the projectile to the stored MouseTarget coordinates
        transform.position = Vector3.MoveTowards(transform.position, translatePos, projectileSpeed);
        if (transform.position == translatePos) // Once the projectile reaches its destination, destroy it
        {
            Destroy(gameObject);
        }
    }
}
