using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetos : MonoBehaviour
{


    public GameObject objeto,objeto1,objeto2;
    public float TimeBetweenObjects;
    float timee;
    Vector3 Pos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int a = Random.Range(0, 2);
        if (a == 0)
        {
            Pos = objeto1.transform.position;
        }
        if (a == 1)
        {
            Pos = objeto2.transform.position;
        }
        if (timee < 0)
        {
            Instantiate(objeto, Pos, objeto1.transform.rotation);
            timee = TimeBetweenObjects;
        }
        else
        {
            timee -= Time.deltaTime;
        }
    }
}
