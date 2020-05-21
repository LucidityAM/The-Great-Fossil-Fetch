using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Camera Camera;
    public GameObject Player;
    public float smoothTimeX;
    public float smoothTimeY;
    private Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float posX = Mathf.SmoothDamp(Camera.transform.position.x, Player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(Camera.transform.position.y, Player.transform.position.y, ref velocity.y, smoothTimeY);

        Camera.transform.position = new Vector3(posX, posY, Camera.transform.position.z);
    }
}
