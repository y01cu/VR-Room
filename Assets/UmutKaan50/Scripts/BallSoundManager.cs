using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BallSoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private XRGrabInteractable xRGrabInteractable;

    [SerializeField] private Rigidbody rigidbody;
    private bool isTouchingGround = false;

    private bool isBallGrabbedBefore = false;

    private void Update()
    {
        UpdateBallState();
    }

    private void UpdateBallState()
    {
        if(xRGrabInteractable.isSelected)
        {
            StartCoroutine(SetBallAsGrabbedAfterSomeTime(.7f));
        }
        else
        {
            isBallGrabbedBefore = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(isBallGrabbedBefore && !isBallStayingInTheGround)
        {
            Debug.LogWarning("Ball hitted ground!");
            audioSource.Play();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.LogWarning("Ball stays in the ground.");

    }

    private void OnCollisionExit(Collision collision)
    {
        isTouchingGround = false;
    }

    private bool isBallStayingInTheGround;

    private IEnumerator SetBallAsGrabbedAfterSomeTime(float time)
    {
        yield return new WaitForSeconds(time);
        isBallGrabbedBefore = true;
    }
}