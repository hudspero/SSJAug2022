// Object: Doorways
// Purpose: Snap the camera to the adjacent room on the same axis when the player enters the doorway

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapCameraX : MonoBehaviour
{
    private GameObject playerObject, cameraObject;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
        cameraObject = GameObject.Find("Camera");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cameraObject.transform.Translate(playerObject.GetComponent<PlayerController>().horizontalInput * 5, 0, 0);
        }
    }
}
