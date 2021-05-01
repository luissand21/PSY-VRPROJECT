using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArithSpawn : MonoBehaviour
{
    public GameObject numberPrefab;
    float nextTime = 0.0f;

    void Start()
    {
        nextTime = Time.time + Random.Range(10.0f, 20.0f);
    }

    void Update()
    {
        if (Time.time >= nextTime)
        {
            nextTime = Time.time + Random.Range(GetAugmentedRange(), GetAugmentedRange() + GetAugmentedRange());
            SpawnRandomNumber();
        }
    }

    void SpawnRandomNumber()
    {
        GameObject go = Instantiate(numberPrefab, null);
        go.transform.position = transform.position + (Random.insideUnitSphere * (Random.Range(0.1f, 4.5f)));
    }

    float GetAugmentedRange()
    {
        float alteredTime = Mathf.Clamp(Mathf.Pow(10.0f, -(Time.timeSinceLevelLoad / 100)), 0.1f, 20);
        return alteredTime;
    }
}
