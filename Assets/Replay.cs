using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Replay : MonoBehaviour
{
    public bool Rep;
    public static Replay replay;
    void Awake()
    {
        if (replay == null)
        {
            replay = this;
            DontDestroyOnLoad(gameObject);
        }
        if (replay!=this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rep = true;
    }
}
