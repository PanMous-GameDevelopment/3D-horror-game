using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinGame : MonoBehaviour
{
    [Header("Inventory")]
    public InventoryObject inventory;

    private void OnTriggerEnter()
    {
        inventory.Container.Clear();
        SceneManager.LoadScene(2);
    }
  
}
