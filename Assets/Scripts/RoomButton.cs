using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomButton : MonoBehaviour
{

    public string newScene;
    public Transform buttonTop;
    private float zOffset;
    private bool isPressed = false;

    void Start()
    {
        zOffset = buttonTop.localPosition.z;
    }

    void FixedUpdate()
    {
        float z = buttonTop.localPosition.z;

        if (!isPressed && (z / zOffset) <= 0.5)
        {
            isPressed = true;
            SceneManager.LoadScene(newScene);
        }
        else if (isPressed && (z / zOffset) > 0.5)
            isPressed = false;
    }
}
