using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Rigidbody theRigidbody;
    public float  damage;
   // private Transform target;

    public float hitWaitTime = 0.5f;
    private float hitCounter;



    // Update is called once per frame
    void FixedUpdate()
    {
        //theRigidbody.velocity = (target.position - transform.position).;

        if (hitCounter > 0)
        {
            hitCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (PlayerHealth.instance.tag == "Player" && hitCounter <= 0f)
        {
            PlayerHealth.instance.TakeDamage(damage);
            hitCounter = hitWaitTime;
        }
    }
}
