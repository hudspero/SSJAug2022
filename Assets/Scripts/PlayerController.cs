// Object: Player
// Purpose: Movement and shooting through the world

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    private float playerSpeed = 3f;

    public bool canShoot = true;
    public float fireRate = 0.5f;
    public float nextShot = -1f;

    public GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        // Get input from keys and move the player
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerSpeed); //Vector3.right = (1, 0, 0)
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * playerSpeed); //Vector3.forward = (0, 0, 1)

        // Set fire rate cap
        if (Time.time > nextShot)
        {
            canShoot = true;
        }

        // Click to shoot
        if (Input.GetKeyDown(KeyCode.Mouse0) && canShoot)
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            canShoot = false;
            nextShot = Time.time + fireRate;
        }
    }
}
