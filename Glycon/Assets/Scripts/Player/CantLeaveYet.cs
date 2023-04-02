using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CantLeaveYet : MonoBehaviour
{
    public GameObject text;
    
    void Start()
    {
        text.SetActive(false);
    }

    private void OnTriggerEnter()
    {
        text.SetActive(true);
        StartCoroutine("WaitForSec");
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        text.SetActive(false);
    }
}
