﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool changeGravity,grounded,start;
    private Rigidbody2D rb2D;
    public float xvelocity,yvelocity,jumpforce;
    public ParticleSystem salto;
    Vector2 vec,vac;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        vec = new Vector2(0, 0);
        start = false;
    }
    void FixedUpdate()
    {
        if (grounded)
        {
           rb2D.velocity = (vec);
        }


    }
    public void Button()
    {
        if (grounded)
        {
            grounded = false;
            xvelocity *= -1;
            vec = new Vector2(-xvelocity, yvelocity);
            vac = new Vector2(0, jumpforce);
            rb2D.velocity = new Vector2(-xvelocity, 0);
            rb2D.AddForce(vac);
            salto.Play();
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
