using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public void Rereset()
    {
        GetComponent<Image>().DOColor(new Color(0, 0, 0, 1.0f), 0.5f);
        Invoke("ResetScene", 1.0f);
    }

    public void ResetScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
