using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float groundDist;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>(); // For 3D, if you're using 2D, change to Rigidbody2D
        sr = gameObject.GetComponent<SpriteRenderer>(); // Ensure sr is assigned
        rb.freezeRotation = true; // Freeze rotation to avoid flipping issues
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;
        
        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if (hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // Log the x value for debugging
        Debug.Log("Horizontal Input: " + x);

        Vector3 moveDir = new Vector3(x, 0, y);
        rb.velocity = moveDir * speed;

        // Simplified flipping logic
        if (x < 0)
        {
            sr.flipX = true;  // Flip sprite to the left
        }
        else if (x > 0)
        {
            sr.flipX = false; // Flip sprite to the right
        }

        // Check for mouse click to fire the weapo
}
}