using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WinOrLose : MonoBehaviour
{

    public GameObject cat1;
    public GameObject cat2;
    public GameObject cat3;
    public GameObject cat4;

    public GameObject gamePanel;

    public Text textDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == cat1)
        {
            Debug.Log("hola");
            gamePanel.gameObject.SetActive(true);
            textDisplay.text = cat1.name + "Win";
            GameObject.Find("GameManager").GetComponent<ButtonMashingEvent>().enabled = false;
        }

        if(collision.gameObject == cat2)
        {
            gamePanel.gameObject.SetActive(true);
            textDisplay.text = cat2.name + "Win";
            GameObject.Find("GameManager").GetComponent<ButtonMashingEvent>().enabled = false;
        }

        if(collision.gameObject == cat3)
        {
            gamePanel.gameObject.SetActive(true);
            textDisplay.text = cat3.name + "Win";
            GameObject.Find("GameManager").GetComponent<ButtonMashingEvent>().enabled = false;
        }

        if(collision.gameObject == cat4)
        {
            gamePanel.gameObject.SetActive(true);
            textDisplay.text = cat4.name + "Win";
            GameObject.Find("GameManager").GetComponent<ButtonMashingEvent>().enabled = false;
        }
    }
}
