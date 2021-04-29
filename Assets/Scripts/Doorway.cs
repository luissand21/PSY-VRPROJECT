using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.OpenXR;

public class Doorway : MonoBehaviour
{
    public Doorway linkedDoor;
    public GameObject doorway;
    public Camera doorCamera;

    public RenderTexture doorRT;
    public Material doorMat;
    public MeshRenderer doorwayMR;

    private bool ignoreTransport = false;

    private void Start()
    {
        if (linkedDoor == null)
            enabled = false;

        if (linkedDoor.linkedDoor != null && linkedDoor.linkedDoor != this)
            enabled = false;

        if (!isActiveAndEnabled)
            return;

        if (linkedDoor.linkedDoor == null)
        {
            linkedDoor.linkedDoor = this;
            //linkedDoor.SetupRenderTexture(this);
        }

        //SetupRenderTexture(linkedDoor);
    }

    /*void FixedUpdate()
    {
        linkedDoor.SetCameraOffset(transform.InverseTransformPoint(Camera.main.transform.position),
                transform.InverseTransformDirection(Camera.main.transform.forward));
    }*/

    public void OnTriggerEnter(Collider other)
    {
        if(!ignoreTransport)
        {
            linkedDoor.ReceiveTransport();
            other.transform.root.position = linkedDoor.transform.TransformPoint(transform.InverseTransformPoint(other.transform.root.position));
            other.transform.root.rotation = Quaternion.LookRotation(linkedDoor.transform.TransformDirection(transform.InverseTransformPoint(other.transform.root.forward)));
        }
    }

    public void OnTriggerExit(Collider other)
    {
        ignoreTransport = false;
    }

    void SetupRenderTexture(Doorway linkedDoor)
    {
        doorwayMR = doorway.GetComponent<MeshRenderer>();
        doorMat = new Material(Shader.Find("Unlit/ScreenCutoutShader"));
        doorRT = new RenderTexture(512, 512, 32, RenderTextureFormat.ARGB32);
        doorMat.SetTexture("_MainTex", doorRT);
        Camera linkedCamera = linkedDoor.GetDoorCamera();
        linkedCamera.targetTexture = doorRT;
        doorwayMR.sharedMaterial = doorMat;
    }

    public Camera GetDoorCamera()
    {
        return doorCamera;
    }

    public void SetCameraOffset(Vector3 offset, Vector3 direction)
    {
        offset.x = -offset.x;
        offset.z = -offset.z;

        direction.x = -direction.x;
        direction.z = -direction.z;

        doorCamera.transform.localPosition = offset;
        doorCamera.transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }

    public void ReceiveTransport()
    {
        ignoreTransport = true;
    }
}
