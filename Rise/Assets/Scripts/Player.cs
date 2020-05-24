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
        rb2D.velocity = new Vector2(gravity, 0);
        if (Input.GetMouseButtonDown(0) && grounded)
        {
            gravity=gravity*-1;
        }
    }
}
