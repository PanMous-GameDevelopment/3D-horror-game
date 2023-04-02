using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFogPosition : MonoBehaviour
{

    public float offset = 1f; // Distance between object and terrain surface.
    private Terrain terrain;

    void Start()
    {
        terrain = Terrain.activeTerrain; // Get the active terrain in the scene.
    }


    void Update()
    {
        // Get the height of the terrain at the object's current position.
        float terrainHeight = terrain.SampleHeight(transform.position);

        // Set the object's position to the terrain height plus the offset.
        transform.position = new Vector3(transform.position.x, terrainHeight + offset, transform.position.z);
    }
}

