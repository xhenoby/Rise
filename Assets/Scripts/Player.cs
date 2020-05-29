using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public ControladorDeUI uiManager;
    public bool changeGravity,grounded,start;
    private Rigidbody2D rb2D;
    public float xvelocity,yvelocity,TiempoVelocidad,VelocidadLimite;
    public ParticleSystem salto;
    private AudioSource aS;
    private float jumpforce,temporizador;
    Vector2 vec,vac;

    private int score;
    private int scoreMts;
    
    [HideInInspector] public bool dead = false;
    
    [Header("Player Sounds")] 
    public AudioClip player_death;
    public AudioClip player_currency;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        vec = new Vector2(0, 0);
        start = false;
        aS = GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        if (grounded && !dead)
        {
           rb2D.velocity = (vec);
        }
        jumpforce =yvelocity*650/10;
        if (temporizador < 0)
        {
            if (yvelocity < 30)
            {
                yvelocity *= 1.1f;
            }
            else
            {
                yvelocity = VelocidadLimite;
            }
            temporizador = TiempoVelocidad;
        }
        else
        {
            temporizador -= Time.deltaTime;
        }
        
        if (!dead)
        {
            scoreMts = Mathf.FloorToInt(transform.position.y)+9;
            uiManager.UpdateScoreUI(score, scoreMts);
        }
    }
    
    public void Button()
    {
        if (grounded && !dead)
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

    public void Kill()
    {
        if (!dead)
        {
            dead = true;
            ChangePitchToNormal();
            aS.PlayOneShot(player_death);
            uiManager.Gameover();
        }
    }

    public void GrabCoin()
    {
        if (!dead)
        {
            CancelInvoke("ChangePitchToNormal");
            aS.pitch += 0.1f;
            aS.PlayOneShot(player_currency);
            score += 1;
            Invoke("ChangePitchToNormal", 1.0f);
        }
    }

    public void ChangePitchToNormal()
    {
        aS.pitch = 1;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Wall"))
        {
            grounded = true;
        }
    }
}
