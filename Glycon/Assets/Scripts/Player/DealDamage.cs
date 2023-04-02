using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public float damageAmount;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            FirstPersonController.OnTakeDamage(damageAmount);
    }
}
