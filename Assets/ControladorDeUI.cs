using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class ControladorDeUI : MonoBehaviour
{
    public GameObject MenuInicio, MenuGameover,Boton,Replay;
    public bool replay;

    void Start()
    {
        Replay = GameObject.FindGameObjectWithTag("Replay");
        replay = Replay.GetComponent<Replay>().Rep;
        if (replay)
        {
            MenuGameover.SetActive(false);
            MenuInicio.SetActive(false);
            Boton.SetActive(true);
        }
        if (!replay)
        {
            MenuInicio.SetActive(true);
            Boton.SetActive(false);
            MenuGameover.SetActive(false);
            
        }
        replay = true;
    }
    public void Play()
    {
        MenuInicio.SetActive(false);
        Boton.SetActive(true);

    }
    public void Reset()
    {
        Replay = GameObject.FindGameObjectWithTag("Replay");
        replay = Replay.GetComponent<Replay>().Rep;
        replay = true;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }
    public void Exit()
    {
        Replay = GameObject.FindGameObjectWithTag("Replay");
        Destroy(Replay);
        Application.Quit();
    }
}
