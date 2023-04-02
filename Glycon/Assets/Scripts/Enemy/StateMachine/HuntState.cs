using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HuntState : State
{
    [Header("Other states")]
    public RoamState roamState;
    public AttackState attackState;

    [Header("Enemy Stats")]
    public GameObject monster;
    public NavMeshAgent agent;
    public Transform player;
    public float detectionRange, attackRange;
    public bool playerInDetectionRange, playerInAttackRange;
    public LayerMask Player;

    

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

        // If the player is in detection range and also in attack range then return the attack state as the current state.
        if (playerInDetectionRange && playerInAttackRange)
        {
            return attackState;
        } // Else if the player is NOT in detection range and also NOT in attack range then return the roam state as the current state.
        else if (!playerInDetectionRange && !playerInAttackRange)
        {
            return roamState;
        } // Otherwise remain in this state.
        else
        {
            return this;
        }

    }
}
