using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contract : MonoBehaviour
{
    public GameObject contractText;
    public GameObject contract;
    private bool contractIsOpen = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            contractText.SetActive(false);

            if (contractIsOpen == false)
            {
                contract.SetActive(true);
                contractIsOpen = true;
            }
            else if (contractIsOpen == true)
            {
                contract.SetActive(false);
                contractIsOpen = false;
            }
            
            
        }
        
    }
}
