using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDot : MonoBehaviour
{
    public void Activate()
    {
        gameObject.SetActive(true);
        StartCoroutine(LateStart(5f));
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //Your Function You Want to Call
        gameObject.SetActive(false);
    }
}
