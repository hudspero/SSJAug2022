// Object: Player/Enemy
// Purpose: Detect if collision occurs, destroy only if incoming object is a Projectile

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private Collider objectCollider;

    void Start()
    {
        objectCollider = GetComponent<Collider>();
    }

    // If a specific projectile enters collision field (Box Collider), destroy the Player/Enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == GameObject.Find("Projectile(Clone)") && (gameObject == GameObject.Find("EnemyD(Clone)") || gameObject == GameObject.Find("EnemyN(Clone)")))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject == GameObject.Find("EnemyProjectile(Clone)") && gameObject == GameObject.Find("Player"))
        {
            Destroy(gameObject);
        }
    }
}

