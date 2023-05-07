using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NotebookCoverController : MonoBehaviour
{
    [SerializeField] private HingeJoint hingeJoint;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private XRGrabInteractable xRGrabInteractable;
    private bool isGrabbed;

    private void Start()
    {
    }

    private void Update()
    {
        isGrabbed = xRGrabInteractable.isSelected;
        // Instead of checking it in update if there could be an event firing up I could've add functions above into it.
        if(isGrabbed)
        {
            ActivateGravity();
        }
    }

    private void ActivateGravity()
    {
        rigidbody.useGravity = true;
        Debug.Log("gravity's active");
    }


}
