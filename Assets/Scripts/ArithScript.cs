using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArithScript : MonoBehaviour
{
    public Text text;
    public float risingSpeed = 0.5f;

    private void Start()
    {
        int random = Random.Range(0, 9);
        text.text = random.ToString();

        Destroy(this, 10);
    }

    private void FixedUpdate()
    {
        Vector3 pos = transform.position;
        pos.z += risingSpeed * Time.deltaTime;
        transform.position = pos;

        Transform aimPoint = Camera.main.transform;
        Vector3 aimDir = (aimPoint.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(aimDir);

    }
}
