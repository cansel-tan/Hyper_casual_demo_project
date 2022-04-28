using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnGameEndCollision : MonoBehaviour
{
   // bool gameOver = false;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("StaticObstacle"))
        {
            //Invoke("restart", 1f);
            //gameOver = false;

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }


    }

    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //gameOver = false;
    }
}
