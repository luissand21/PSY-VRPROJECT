using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandHider : MonoBehaviour
{
    private SkinnedMeshRenderer meshRenderer = null;
    private XRDirectInteractor interactor = null;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        interactor = GetComponent<XRDirectInteractor>();

        interactor.hoverEntered.AddListener(Hide);
        interactor.hoverExited.AddListener(Show);
    }

    private void OnDestroy()
    {
        interactor.hoverEntered.RemoveListener(Hide);
        interactor.hoverExited.RemoveListener(Show);
    }

    private void Show(HoverExitEventArgs args)
    {
        meshRenderer.enabled = true;
    }

    private void Hide(HoverEnterEventArgs args)
    {
        meshRenderer.enabled = false;
    }
}
