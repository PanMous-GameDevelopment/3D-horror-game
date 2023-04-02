using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawner : MonoBehaviour
{

    public List<GameObject> spiders; // List of spiders to activate.
    public float activateDelay = 300f; // The delay between spawns in seconds.
    public int spiderCount = 0;
 
    void Start()
    { 
            StartCoroutine(ActivateSpider());
            spiderCount++; // Starts counting the spiders that are being activated.   
    }

    IEnumerator ActivateSpider()
    {
        while ( spiderCount < 11 ) // Keep the loop until there are 10 spiders in total activated.
        {
            yield return new WaitForSeconds(activateDelay); // Wait for set seconds.

            int randomIndex = Random.Range(0, spiders.Count); // Gets a random integer between 0 and the list size.
            GameObject randomSpider = spiders[randomIndex]; // Gets the spider with the same index in the list, as the random index set above.
            randomSpider.SetActive(true);
            spiders.RemoveAt(randomIndex); // Removes that specific spider from the list in order to not get selected again.

            spiderCount++;
        }
        


    }
}
