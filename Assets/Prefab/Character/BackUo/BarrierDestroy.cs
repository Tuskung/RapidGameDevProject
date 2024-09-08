using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierDestroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the barrier when it collides with an enemy
            Destroy(gameObject);
        }
    }
}
