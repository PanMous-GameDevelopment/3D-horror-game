using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralWalkAnimation : MonoBehaviour
{
    public Transform[] legTargets;
    public float stepSize = 1f;
    public float stepHeight = 0.5f;
    public int smoothness = 10; //Animation smoothness used in the coroutine.  

    private float raycastRange = 1f;
    private Vector3[] defaultLegPositions;
    private Vector3[] lastLegPositions;
    private Vector3 lastBodyUp;
    private bool[] legMoving;
    private int legsNumber;

    private Vector3 velocity;
    private Vector3 lastVelocity;
    private Vector3 lastBodyPos;

    private float velocityMultiplier = 15f;

    //Cast raycast from the targets to keep the legs on the surface.
    static Vector3[] RaycastCheckSurface(Vector3 point, float halfRange, Vector3 up)
    {
        Vector3[] res = new Vector3[2];
        RaycastHit hit;
        Ray ray = new Ray(point + halfRange * up, -up);

        if (Physics.Raycast(ray, out hit, 2f * halfRange))
        {
            res[0] = hit.point;
            res[1] = hit.normal;
        }
        else
        {
            res[0] = point;
        }
        return res;
    }

    //Set the default position of each leg at the start of the game.
    void Start()
    {
        lastBodyUp = transform.up;

        legsNumber = legTargets.Length;
        defaultLegPositions = new Vector3[legsNumber];
        lastLegPositions = new Vector3[legsNumber];
        legMoving = new bool[legsNumber]; //Moving status for each leg.
        for (int i = 0; i < legsNumber; ++i)
        {
            defaultLegPositions[i] = legTargets[i].localPosition; //Sets as default leg position the local position of its target.
            lastLegPositions[i] = legTargets[i].position;
            legMoving[i] = false; //Setting them all to non moving.
        }
        lastBodyPos = transform.position;
    }

    //Position calculations.
    void FixedUpdate()
    {
        //Calculate the current velocity.
        velocity = transform.position - lastBodyPos;
        velocity = (velocity + smoothness * lastVelocity) / (smoothness + 1f);

        if (velocity.magnitude < 0.000025f)
            velocity = lastVelocity;
        else
            lastVelocity = velocity;

        //Create and set the desired positions for each leg. Then calculate the distance to travel with each step.
        Vector3[] desiredPositions = new Vector3[legsNumber];
        int legToMove = -1;
        float maxDistance = stepSize;
        for (int i = 0; i < legsNumber; ++i)
        {
            desiredPositions[i] = transform.TransformPoint(defaultLegPositions[i]); //Transforms from local space to world space.

            //Calculating the distance based on the desired position and the velocity.
            float distance = Vector3.ProjectOnPlane(desiredPositions[i] + velocity * velocityMultiplier - lastLegPositions[i], transform.up).magnitude;
            if (distance > maxDistance)
            {
                maxDistance = distance;
                legToMove = i;
            }
        }

        //Keep the stable legs in place. 
        for (int i = 0; i < legsNumber; ++i)
            if (i != legToMove)
                legTargets[i].position = lastLegPositions[i];

        //Move the leg to its desired position.
        if (legToMove != -1 && !legMoving[0])
        {
            Vector3 targetPoint = desiredPositions[legToMove] + Mathf.Clamp(velocity.magnitude * velocityMultiplier, 0.0f, 1.5f) * (desiredPositions[legToMove] - legTargets[legToMove].position) + velocity * velocityMultiplier;
            Vector3[] positionAndNormal = RaycastCheckSurface(targetPoint, raycastRange, transform.up);
            legMoving[0] = true;
            StartCoroutine(Step(legToMove, positionAndNormal[0]));
        }

        lastBodyPos = transform.position;
    }

    //Gradual movement animation during the step.
    IEnumerator Step(int legIndex, Vector3 targetPoint)
    {
        Vector3 startPos = lastLegPositions[legIndex];
        //Using the smoothness variable to control the animation smoothness. 
        for (int i = 1; i <= smoothness; ++i)
        {
            //Using lerp for linear interpolation with the stepHeight variable to create the leg curve movement.
            legTargets[legIndex].position = Vector3.Lerp(startPos, targetPoint, i / (float)(smoothness + 1f));
            legTargets[legIndex].position += transform.up * Mathf.Sin(i / (float)(smoothness + 1f) * Mathf.PI) * stepHeight;
            yield return new WaitForFixedUpdate();
        }
        legTargets[legIndex].position = targetPoint;
        lastLegPositions[legIndex] = legTargets[legIndex].position;
        legMoving[0] = false;
    }
}
