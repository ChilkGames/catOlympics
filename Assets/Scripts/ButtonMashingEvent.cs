using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMashingEvent : MonoBehaviour
{

    public GameObject cat1;
    public GameObject cat2;
    public GameObject cat3;
    public GameObject cat4;

    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ButtonMashing();
    }

    void ButtonMashing()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            cat1.transform.position += new Vector3(10, 0, 0) * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            cat2.transform.position += new Vector3(10, 0, 0) * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            cat3.transform.position += new Vector3(10, 0, 0) * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            cat4.transform.position += new Vector3(10, 0, 0) * speed * Time.deltaTime;
        }
    }
}
