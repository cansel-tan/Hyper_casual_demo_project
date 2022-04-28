using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Paintable : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Brush;
    public float BrushSize = 0.2f;
    //public RenderTexture RTexture;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //cast a ray to the plane
      
            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log(Input.mousePosition);
            RaycastHit hit;
            if(Input.mousePosition.x>370 && Input.mousePosition.y > 20 && Input.mousePosition.y < 390 && Input.mousePosition.x < 1090)
            {
                if (Physics.Raycast(Ray, out hit))
                {
                    //instanciate a brush
                    var go = Instantiate(Brush, hit.point + Vector3.up * 0.01f, Quaternion.identity, transform);
                    go.transform.localScale = Vector3.one * BrushSize;
                }
            }
          

        }
    }
    




}
