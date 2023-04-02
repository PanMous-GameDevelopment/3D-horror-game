using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int counter;
    public int eggNumber;
    public GameObject textArea;
    public GameObject winGame;

    void Update()
    {
      // Check if the counter is equal to the required number to finish the game.
      if (counter == eggNumber) // Win condition.
        {
            textArea.SetActive(false);
            winGame.SetActive(true);
        }
    }

    // Rise the counter. Call this function every time an egg is being picked up.
    public void Counter()
    {
        counter++; 
    }
}
