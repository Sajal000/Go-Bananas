using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public string nextScene;

    private void OnTriggerEnter2D (Collider2D collision)
    {
  
        if (collision.CompareTag("Player"))
        {
            var bananas = GameObject.FindGameObjectsWithTag("Banana");
            Debug.Log(bananas.Length);
           
            if (bananas.Length == 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
            }

        }
    } 
}
