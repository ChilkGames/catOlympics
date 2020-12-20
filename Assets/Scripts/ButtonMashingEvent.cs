using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMashingEvent : NetworkBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if(isLocalPlayer){
            ButtonMashing();
        }
    }

    void ButtonMashing()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += new Vector3(10, 0, 0) * speed * Time.deltaTime;
        }
    }
}
