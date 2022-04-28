using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject boy;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("finish"))
        {
            SceneManager.LoadScene("Level2");

        }
        else if (other.collider.CompareTag("gameOver"))
        {
            SceneManager.LoadScene("Level3");

        }


    }
}
