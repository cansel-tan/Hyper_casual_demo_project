using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Characters
{
    public Characters(string name, float distance)
    {
        Name = name;
        Distance = distance;
    }

    public string Name { get; set; }
    public float Distance { get; set; }
}
public class PlayerArrangement : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Boy;
    public GameObject Finish;
    public GameObject[] Girls;
    public List<Characters> distances = new List<Characters>();
    private Text arrangement;
    private float currentDistance = 1000;
    public GameObject arrangementGame;
    void Start()
    {
        arrangement = arrangementGame.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        distances = new List<Characters>();
        foreach (GameObject objectP in Girls) {
            var distance = Vector3.Distance(objectP.transform.position, Finish.transform.position);

           
            distances.Add(new Characters(objectP.name, distance));
         
 }

        distances.Sort((x, y) => x.Distance.CompareTo(y.Distance));

        arrangement.text = (distances.FindIndex(x => x.Name == "Boy")+1).ToString() + ". Sıradasınız";

       


        
    }
}
