
using System;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public GameObject Player;
    public float smoth = 0.9f, minXcamera,offset;
    private Player playerSc;
    private float maxXcamera;

    private void Start()
    {
        playerSc = Player.GetComponent<Player>();
    }

    void FixedUpdate()
    {
        if (!playerSc.dead)
        {
            maxXcamera = Player.transform.position.y + 100;
            float posY = Mathf.Lerp(transform.position.y, Player.transform.position.y + offset, smoth);
            transform.position = new Vector3(transform.position.x, posY,
                transform.position.z);
        }
    }
}
