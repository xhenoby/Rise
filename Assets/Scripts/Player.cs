using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public ControladorDeUI uiManager;
    public bool changeGravity,grounded,start;
    private Rigidbody2D rb2D;
    public float xvelocity,yvelocity,TiempoVelocidad,VelocidadLimite;
    public ParticleSystem salto;
    private AudioSource aS;
    private AudioSource aS2;
    private float jumpforce,temporizador;
    Vector2 vec,vac;

    private Animator anim;
    private GameObject playerModel;
    private bool walking;
    private bool jumping;
    private bool started;
    private bool side;

    private int score;
    private int scoreMts;
    
    [HideInInspector] public bool dead = false;
    
    [Header("Player Sounds")] 
    public AudioClip player_death;
    public AudioClip player_currency;
    public AudioClip player_Jump1;
    public AudioClip player_Jump2;

    private AudioClip RandomJump;
    void Start()
    {
        playerModel = transform.GetChild(0).gameObject;
        anim = playerModel.GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        vec = new Vector2(0, 0);
        start = false;
        aS = GetComponents<AudioSource>()[0];
        aS2 = GetComponents<AudioSource>()[1];
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
        int jum = UnityEngine.Random.Range(0,2);
        if (jum == 0)
        {
            RandomJump = player_Jump1;
        }
        else
        {
            RandomJump = player_Jump2;

        }

        if (!started)
        {
            started = true;
            anim.SetBool("started", started);
            playerModel.transform.DOLocalRotate(new Vector3(-90, 90, 0), 0.5f);
        }

        if (grounded && !dead)
        {
            grounded = false;
            side = !side;
            anim.SetBool("jumping", true);
            anim.SetBool("walking", false);
            playerModel.transform.DOScaleY(side?0.5f:-0.5f, 0f);
            xvelocity *= -1;
            vec = new Vector2(-xvelocity, yvelocity);
            vac = new Vector2(0, jumpforce);
            rb2D.velocity = new Vector2(-xvelocity, 0);
            rb2D.AddForce(vac);
            aS2.PlayOneShot(RandomJump);
            salto.transform.localEulerAngles *= -1;
            salto.Play();
        }
    }

    public void Kill()
    {
        if (!dead)
        {
            dead = true;
            ChangePitchToNormal();
            anim.SetBool("jumping", false);
            anim.SetBool("walking", false);
            anim.Play("Death");
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
            anim.SetBool("jumping", false);
            anim.SetBool("walking", true);
            grounded = true;
        }
    }
}
