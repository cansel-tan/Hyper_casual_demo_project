using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject boy;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("gameOver"))
        {
            SceneManager.LoadScene("Level3");

        }
       


    }
}
