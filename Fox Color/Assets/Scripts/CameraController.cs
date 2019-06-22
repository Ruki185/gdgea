using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;       //Public variable to store a reference to the player game object
    public float offset = -10;

    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = new Vector3(0,transform.position.y,0) + new Vector3(player.transform.position.x, 0, offset);
    }
}