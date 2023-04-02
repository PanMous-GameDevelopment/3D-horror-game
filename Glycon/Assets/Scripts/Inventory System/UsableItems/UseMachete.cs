using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMachete : MonoBehaviour
{
    public InventoryObject inventory;
    public ItemObject itemMachete;
    public Camera playerCamera;
    [SerializeField] private Vector3 interactionRayPoint = default;
    [SerializeField] private float interactionDistance = default;
    [SerializeField] private KeyCode WebInteraction = KeyCode.Mouse0;
    public AudioSource webAudio;

    void Update()
    { // Checks if there are webs in front of the player.
        if (Physics.Raycast(playerCamera.ViewportPointToRay(interactionRayPoint), out RaycastHit hit, interactionDistance))
        { 
            if (hit.collider.gameObject.layer == 9)
            { 
                if (Input.GetKeyDown(WebInteraction))
                {
                    int i = 0; // Checks the inventory if it has a machete item.
                    foreach (var x in inventory.Container)
                    { // If it has, then deactivate the web in front of the player.
                        if (inventory.Container[i].item == itemMachete)
                        {
                            webAudio.Play();
                            hit.collider.gameObject.SetActive(false);
                        }
                        i++;
                    }
                }
            }
        }
    }
  
}
