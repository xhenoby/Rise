using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool changeGravity,grounded;
    private Rigidbody2D rb2D;
    public float gravity;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(1f, 0);
    }
    void Update()
    {
        Vector2 vec = new Vector2(gravity,0);
        rb2D.AddForce(vec);
        if (Input.GetMouseButtonDown(0) && grounded)
        {
            grounded = false;
            gravity *= -1;
        }
    }
    public void Button()
    {
        if (grounded)
        {
            grounded = false;
            gravity *= -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Wall"))
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Object")
        {
            Debug.Log("Object hit");
        }
    }
}
