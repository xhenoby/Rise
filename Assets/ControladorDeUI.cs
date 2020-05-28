using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorDeUI : MonoBehaviour
{
    public GameObject MenuInicio, MenuGameover,Boton,Replay,black;
    public bool replay;
    public float TiempoTransicion;
    public AudioSource Inicio, GameOver, Playing;

    public float TiempoTrancurido;
    public bool transicion1, transicion2;

    void Start()
    {
        Replay = GameObject.FindGameObjectWithTag("Replay");
        replay = Replay.GetComponent<Replay>().Rep;
        if (replay)
        {
            MenuGameover.SetActive(false);
            MenuInicio.SetActive(false);
            Boton.SetActive(true);
            Playing.Play();
            Playing.volume = 0;
            transicion1 = true;
        }
        if (!replay)
        {
            MenuInicio.SetActive(true);
            Boton.SetActive(false);
            MenuGameover.SetActive(false);
            Inicio.Play();

        }
    }
    private void Update()
    {
        if (transicion1)
        {
            TiempoTrancurido += (Time.deltaTime/TiempoTransicion);
            Inicio.volume = Mathf.Lerp(1,0,TiempoTrancurido);
            Playing.volume = Mathf.Lerp(0,1,TiempoTrancurido);
        }
        if (transicion2)
        {
            TiempoTrancurido += (Time.deltaTime/TiempoTransicion);
            GameOver.volume = Mathf.Lerp(0, 1,TiempoTrancurido);
            Playing.volume = Mathf.Lerp(1, 0,TiempoTrancurido);
        }
        if (TiempoTrancurido > 1)
        {
            transicion1 = false;
            transicion2 = false;
        }
    }
    public void Play()
    {
        MenuInicio.SetActive(false);
        Boton.SetActive(true);
        TiempoTrancurido = 0;
        transicion1 = true;
        Playing.Play();
        Playing.volume = 0;
    }
    public void Gameover()
    {
        MenuGameover.SetActive(true);
        GameOver.Play();
        GameOver.volume = 0;
        TiempoTrancurido = 0;
        transicion2 = true;
    }
    public void Exit()
    {
        Replay = GameObject.FindGameObjectWithTag("Replay");
        Destroy(Replay);
        Application.Quit();
    }
}
