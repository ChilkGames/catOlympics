using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDotManager : MonoBehaviour
{

    public List<GameObject> redDot = new List<GameObject>();
    public bool spawnEnabled = true;
    public float spawnTimer = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnEnabled)
        {
            RandomRedDot();
            spawnEnabled = false;
        }
        else
        {
            spawnTimer -= Time.deltaTime;
            if(spawnTimer <= 0)
            {
                spawnEnabled = true;
                spawnTimer = 2;
            } 
        }
        
    }

    void RandomRedDot()
    {
        int randomIndex = Random.Range(0, redDot.Count);

        if(!redDot[randomIndex].gameObject.activeInHierarchy)
        {
            Debug.Log(randomIndex);
            redDot[randomIndex].GetComponent<RedDot>().Activate();
        }
    }
}
