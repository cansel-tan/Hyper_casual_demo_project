using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    private float lastFrameFingerPositionX;
    private float moveFactorX;
    public float MoveFactorX => moveFactorX;
    public float speed = 5;
    public Rigidbody rb;
    public float horizontalInput;

    bool gameOver = false;

    private void FixedUpdate()
    {
        Vector3 forwardMove = transform.forward * speed *Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove+ horizontalMove);
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
       /* if (gameOver == false)
            GetComponent<Rigidbody>().AddForce(Vector3.forward *1/2
                , ForceMode.Force);
        else if (gameOver == true)
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }

        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;

        }

        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
          
        }
        if (GetComponent<Rigidbody>().position.x <= -4)
        {
            gameOver = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            Invoke("restart", 2f);
        }*/



    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "StaticObstacle")
        Invoke("restart", 2f);
        gameOver = true;
    }

    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOver = false;
    }
}
