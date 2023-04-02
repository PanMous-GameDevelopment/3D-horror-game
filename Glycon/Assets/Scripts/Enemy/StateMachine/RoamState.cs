using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoamState : State
{
    [Header("Other states")]
    public HuntState huntState;

    [Header("Enemy Stats")]
    public GameObject monster;
    public NavMeshAgent agent;
    public float range;
    public Transform centerPoint;
    public float detectionRange, attackRange;
    public bool playerInDetectionRange, playerInAttackRange;
    public LayerMask Player;

    [Header("Audio ")]
    public AudioSource screamAudio;

    void Start()
    {
        agent = monster.GetComponent<NavMeshAgent>(); // Getting the navmesh.      
    }

    // Sets a random point on the map based on another point acting as a center (usually the enemy's current position) and a range variable.
    // It finds a point around that center inside the set range.
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; // Sets a random point inside a sphere based on a center point and a range variable.
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    public override State RunCurrentState()
    {
        if (agent.remainingDistance <= agent.stoppingDistance) // Done with path.
        {
            Vector3 point;
            if (RandomPoint(centerPoint.position, range, out point)) // Pass the center point and range.
                agent.SetDestination(point);
        }

        // Sets the player in detection and attack range variables based on the detection and attack range AND the player position.
        playerInDetectionRange = Physics.CheckSphere(transform.position, detectionRange, Player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, Player);

        // If the player is in detection range and NOT in attack range then starts the Scream coroutine and returns the hunt state as the current state.
        if (playerInDetectionRange && !playerInAttackRange)
        {
            StartCoroutine(SpiderScream());
            return huntState;

        } // Otherwise remain in this state.
        else
        {
            return this;
        }

    }

    // Mutes and then unmutes the audio scream after 5 seconds in order to prevent repeating.
    IEnumerator SpiderScream()
    {
        screamAudio.Play();
        
        yield return new WaitForSeconds(5);

        screamAudio.mute = true;

        yield return new WaitForSeconds(5);

        screamAudio.mute = false;
    }


 }
