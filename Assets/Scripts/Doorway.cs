using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorway : MonoBehaviour
{
    public Doorway linkedDoor;
    public GameObject doorway;

    private Camera doorCamera;
    private RenderTexture doorRT;
    private Material doorMat;
    private MeshRenderer doorwayMR;

    private void Awake()
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
            linkedDoor.SetupRenderTexture(this);
        }

        doorCamera = this.GetComponentInChildren<Camera>();

        SetupRenderTexture(linkedDoor);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetupRenderTexture(Doorway linkedDoor)
    {
        doorwayMR = doorway.GetComponent<MeshRenderer>();
        doorMat = new Material(Shader.Find("ScreenCutoutShader"));
        doorRT = new RenderTexture(512, 512, 32, RenderTextureFormat.ARGB32);
        doorMat.SetTexture(0, doorRT);
        Camera linkedCamera = linkedDoor.GetDoorCamera();
        linkedCamera.targetTexture = doorRT;
        doorwayMR.material = doorMat;
    }

    public Camera GetDoorCamera()
    {
        return doorCamera;
    }

    public void SetCameraOffset(Vector3 offset, Vector3 direction)
    {
        doorCamera.transform.localPosition = offset;
        
    }

    private void OnWillRenderObject()
    {
        if(Camera.current == Camera.main)
        {
            linkedDoor.SetCameraOffset(transform.InverseTransformPoint(Camera.main.transform.position),
                transform.InverseTransformDirection(Camera.main.transform.forward));
        }
    }
}
