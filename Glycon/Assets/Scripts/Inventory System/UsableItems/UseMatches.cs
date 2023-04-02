using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMatches : MonoBehaviour
{
    public GameObject Slot;
    public InventoryObject inventory;
    Light MatchesLight;
    public ItemObject itemMatches;
    InventoryObject inventoryObject;
    public ItemObject item;
    public int amountToRemove; 
    public bool drainOverTime;
    public float drainRate;
    public float minBrightness;
    public float maxBrightness;

    public AudioSource lightMatchesAudio;

    void Start()
    {
        MatchesLight = GetComponent<Light>();
        MatchesLight.enabled = false;
    }

 
    void Update()
    {
        MatchesLight.intensity = Mathf.Clamp(MatchesLight.intensity, minBrightness, maxBrightness);
        if (Input.GetKeyDown(KeyCode.F))
        {
            int i = 0; // If the F key is pressed, checks the inventory if it has the item matches.
            foreach (var x in inventory.Container)
            {
                if (inventory.Container[i].item == itemMatches)
                { // If the item matches amount is > 0 then it uses the item.
                    if (inventory.Container[i].amount > 0)
                    {
                        lightMatchesAudio.Play();
                        MatchesLight.intensity = maxBrightness; // Sets the light intensity to max.

                        MatchesLight.enabled = !MatchesLight.enabled;
                        drainOverTime = true; 
                        inventory.Container[i].RemoveAmount(amountToRemove); // Removes the item from the inventory.
                    }

                }             
                i++;
            }
        }
      
        if ( MatchesLight.enabled == true)
        {

            if (MatchesLight.intensity > minBrightness)
            {
                MatchesLight.intensity -= Time.deltaTime * (drainRate / 1000); // Slowly decreases the light intensity.
            }
            else
            {
                MatchesLight.enabled = !MatchesLight.enabled;
                drainOverTime = false;
            }
        }
    }
}
