using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public GameObject stepPrefab;
    private int additionalSteps = 0;

    public void AddStep()
    {
        GameObject go = Instantiate(stepPrefab, transform);
        additionalSteps++;
        go.transform.localPosition = new Vector3(0, 1 + (0.2f * additionalSteps), 1 + (0.2f * additionalSteps));
    }
}
