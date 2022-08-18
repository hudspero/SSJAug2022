// Object: Player
// Purpose: Movement and shooting through the world

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    private int playerSpeed = 2;

    public GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        // Get input from keys and move the player
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * playerSpeed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * playerSpeed);

        // Click to shoot
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }
}
