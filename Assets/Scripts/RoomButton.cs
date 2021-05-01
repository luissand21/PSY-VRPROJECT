using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomButton : MonoBehaviour
{

    public string newScene;
    public Transform buttonTop;
    private float yOffset;
    private bool isPressed = false;

    void Start()
    {
        yOffset = buttonTop.localPosition.y;
    }

    void FixedUpdate()
    {
        float y = buttonTop.localPosition.y;

        if (!isPressed && (y / yOffset) <= 0.5)
        {
            isPressed = true;
            //SceneManager.LoadScene(newScene);
        }
        else if (isPressed && (y / yOffset) > 0.5)
            isPressed = false;
    }
}
