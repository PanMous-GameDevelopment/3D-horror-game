using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackState : State
{
    [Header("Other states")]
    public RoamState roamState;
    public HuntState huntState;

    [Header("Enemy Stats")]
    public GameObject monster;
    public NavMeshAgent agent;
    public Transform player;
    public float detectionRange, attackRange;
    public bool playerInDetectionRange, playerInAttackRange;
    public LayerMask Player;

    [Header("Attack Stats")]
    public float damageAmount;
    public float Cooldown;
    private float AttackDelay = 0f;

    [Header("Audio")]
    public GameObject volumeObject;

    void Start()
    {
        agent = monster.GetComponent<NavMeshAgent>(); // Getting the navmesh.       
    }

    public override State RunCurrentState()
    {
        agent.SetDestination(player.position); // Chase the player.

        // Sets the player in detection and attack range variables based on the detection and attack range AND the player position.
        playerInDetectionRange = Physics.CheckSphere(transform.position, detectionRange, Player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);

        // Checks if the player is in detection range but not in attack range. Then returns the hunt state as the current state.
        if (playerInDetectionRange && !playerInAttackRange)
        {
            return huntState;
        } // Checks if the player is not in detection range and also not in attack range. Then returns the roam state as the current state.
        else if (!playerInDetectionRange && !playerInAttackRange)
        {
            return roamState;
        } // In any other case the enemy is in the attack state and performs the attack action.
        else
        {            
            if ( Time.time > AttackDelay)
            {
                AttackDelay = Time.time + Cooldown; // Attack coodldown.
                FirstPersonController.OnTakeDamage(damageAmount); // Passes the damage amount to the player script.
                volumeObject.GetComponent<DamageEffects>().ChangeEffect(); // Calls the ChangeEffect() function from the DamageEffects script to indicate damage was dealt.
            }          
            return this;
        }        
    }
}
