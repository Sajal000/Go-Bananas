using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    GameObject player; 
     void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        var playerPOS = player.transform.position;
        var cameraPOS = transform.position;

        //cameraPOS.x = playerPOS.x;
        cameraPOS.y = playerPOS.y;

        transform.position = cameraPOS; 
    }
}
