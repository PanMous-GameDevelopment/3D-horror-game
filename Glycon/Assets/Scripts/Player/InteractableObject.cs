using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : Interactable
{
    public GameObject Collectable;
    public GameObject gameManager;
    public AudioSource itemPickAudio;

    public override void OnFocus()
    {
        print("Looking at" + gameObject.name);
    }

    public override void OnLoseFocus()
    {
        print("Stopped looking at" + gameObject.name);
    }

    public override void OnInteract()
    {
        Collectable.SetActive(false); // Deactivates the item that was picked up.
        itemPickAudio.Play();
        if (Collectable.tag == "Egg")
        {
            gameManager.GetComponent<GameManager>().Counter(); // If the item was an egg then it calls the Counter() function from the game manager.         
        }      
    }
}