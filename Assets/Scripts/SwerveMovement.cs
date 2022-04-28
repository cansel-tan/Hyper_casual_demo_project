using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwerveMovement : MonoBehaviour
{
    // Start is called before the first frame update

   
    [SerializeField] float forwardSpeed = 5f;
    [SerializeField] float lerpSpeed = 5f;
    [SerializeField] float playerXValue = 2f;
    [SerializeField] Vector2 clampValues = new Vector2(-2,2);


    private Rigidbody rb;
    private float newXPosition;
    private float startXPosition;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startXPosition = transform.position.x;
    }
     void Update()
    {
       if(Input.GetButtonDown("Horizontal"))
        {
            newXPosition = Mathf.Clamp(transform.position.x + Input.GetAxisRaw("Horizontal") * playerXValue, startXPosition + clampValues.x, startXPosition +clampValues.y);

        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.MovePosition(new Vector3(Mathf.Lerp(transform.position.x, newXPosition, lerpSpeed * Time.fixedDeltaTime), rb.velocity.y, transform.position.z + forwardSpeed * Time.fixedDeltaTime));
    }

  
}
