using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update

    private Transform player;
    private Vector3 startMousePos, startPlayerPos;
    private bool moveThePlayer;
    [Range (0f,1f)]public float maxSpeed;
    [Range(0f, 1f)] public float cameraSpeed;
    [Range(0f, 50f)] public float pathSpeed;


    private float velocity ,cameraVelocity;
    private GameObject platform;
    private Camera mainCamera;
    public Transform path;
    private Rigidbody rb;
    //public bool gameOver = false;

    void Start()
    {

        player = transform;
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody>();
 


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            moveThePlayer = true;
            Plane newPlane = new Plane(Vector3.up, 0f);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(newPlane.Raycast(ray,out var distance))
            {
                startMousePos = ray.GetPoint(distance);
                startPlayerPos = player.position;
            }

           
        }

        else if (Input.GetMouseButtonUp(0))
        {
            moveThePlayer = false;

        }

        if (moveThePlayer)
        {
            Plane newPlane = new Plane(Vector3.up, 0f);
          
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

           if(newPlane.Raycast(ray,out var distance))
            {
                Vector3 mousePos = ray.GetPoint(distance);
                Vector3 mouseNewPos = mousePos - startMousePos;
                Vector3 DesirePlayerPos = mouseNewPos + startPlayerPos;

                DesirePlayerPos.x = Mathf.Clamp(DesirePlayerPos.x, -1.5f, 1.5f);

                player.position = new Vector3(Mathf.SmoothDamp(player.position.x, DesirePlayerPos.x, ref velocity, maxSpeed), player.position.y,player.position.z);
            }
        }

        var pathNewPos = path.position;
        path.position = new Vector3(pathNewPos.x, pathNewPos.y, Mathf.MoveTowards(pathNewPos.z, -1000f, pathSpeed * Time.deltaTime));
       /* if (GetComponent<Rigidbody>().position.x <= -110)
        {
            gameOver = true;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }*/
    }

    private void LateUpdate()
    {
        var CameraNewPos = mainCamera.transform.position;
        mainCamera.transform.position = new Vector3(Mathf.SmoothDamp(CameraNewPos.x, player.transform.position.x, ref cameraVelocity, cameraSpeed), CameraNewPos.y, CameraNewPos.z);
    }

    public void Finish()
    {
        SceneManager.LoadScene("Level3");

    }

}
