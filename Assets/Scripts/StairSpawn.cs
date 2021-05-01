using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairSpawn : MonoBehaviour
{
    public int interval = 10;
    public List<Stairs> stairs;
    private bool stairSpawned = false;

    public void FixedUpdate()
    {
        if ((((int)Time.timeSinceLevelLoad) % interval) == 0 && !stairSpawned)
        {
            stairSpawned = true;
            foreach (Stairs stair in stairs)
                stair.AddStep();
        }
        else if (stairSpawned && (((int)Time.timeSinceLevelLoad) % interval) == 1)
            stairSpawned = false;
    }
}
