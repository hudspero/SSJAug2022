// Object: Doorways
// Purpose: Snap the camera to the adjacent room on the same axis when the player enters the doorway

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapCameraZ : MonoBehaviour
{
    private GameObject playerObject, cameraObject;
    private float cameraXRotation;

    // Start is called before the first frame update
    void Start()
    {
        playerObject = GameObject.Find("Player");
        cameraObject = GameObject.Find("Camera");
        cameraXRotation = 32.875f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cameraObject.transform.Rotate(-cameraXRotation, 0, 0);
            cameraObject.transform.Translate(0, 0, playerObject.GetComponent<PlayerController>().verticalInput * 5);
            cameraObject.transform.Rotate(cameraXRotation, 0, 0);
        }
    }
}
