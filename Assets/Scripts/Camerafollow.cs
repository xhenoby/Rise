
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public GameObject Player;
    public float smoth = 0.9f, minXcamera,offset;
    private float maxXcamera;

    void FixedUpdate()
    {
        maxXcamera = Player.transform.position.y+100;
        float posY = Mathf.Lerp(transform.position.y,Player.transform.position.y+offset,smoth);
        transform.position = new Vector3(transform.position.x,Mathf.Clamp(posY, minXcamera, maxXcamera),transform.position.z);
    }
}
