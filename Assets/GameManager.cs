using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<ButtonMashingEvent> cats = new List<ButtonMashingEvent>();

    // Start is called before the first frame update
    void Start()
    {
        var allCharacters = FindObjectsOfType<ButtonMashingEvent>();

        foreach (var myCharacter in allCharacters)
        {
            var player = myCharacter.GetComponent<ButtonMashingEvent>();

            if (myCharacter.tag == "Player")
                cats.Add(player);
        }
    }
}
