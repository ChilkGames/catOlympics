using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<ButtonMashingEvent> cats = new List<ButtonMashingEvent>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateStart(0.5f));
    }

    IEnumerator LateStart(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        var allCharacters = FindObjectsOfType<ButtonMashingEvent>();

        foreach (var myCharacter in allCharacters)
        {
            if (myCharacter.tag == "Player")
                cats.Add(myCharacter.GetComponent<ButtonMashingEvent>());
        }
    }    
}
