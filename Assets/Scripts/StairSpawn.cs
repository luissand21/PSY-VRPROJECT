using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairSpawn : MonoBehaviour
{
    public List<Stairs> stairs;
    private bool stairSpawned = false;

    public void FixedUpdate()
    {
        if ((((int)Time.timeSinceLevelLoad) % 10) == 0 && !stairSpawned)
        {
            stairSpawned = true;
            foreach (Stairs stair in stairs)
                stair.AddStep();
        }
        else if (stairSpawned && (((int)Time.timeSinceLevelLoad) % 10) == 1)
            stairSpawned = false;
    }
}
