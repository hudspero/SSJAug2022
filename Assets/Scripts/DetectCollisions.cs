// Object: Projectile and EnemyProjectile
// Purpose: Detect if collision occurs

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
        if (gameObject == GameObject.Find("Projectile(Clone)") && (other.gameObject.CompareTag("Enemy")))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else if (gameObject == GameObject.Find("EnemyProjectile(Clone)") && other.gameObject == GameObject.Find("Player"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
    }
}

