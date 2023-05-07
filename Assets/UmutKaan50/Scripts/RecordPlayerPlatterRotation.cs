using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordPlayerPlatterRotation : MonoBehaviour
{
    [SerializeField] private Vector3 rotationVector;
    private void RotatePlatter()
    {
        transform.Rotate(rotationVector * Time.deltaTime);
    }

    private void Update()
    {
        RotatePlatter();
    }
}
