using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [Header("Animation and Level")]
    public Animator animator;
    public int levelToLoad;

    [Header("Inventory")]
    public InventoryObject inventory;

    public void ChangeScene()
    {
        FadeToLevel(levelToLoad);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut"); // Set the trigger for the fade out animation.
        inventory.Container.Clear(); // Clear the inventory.
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad); // Load the required scene.      
    }
}
