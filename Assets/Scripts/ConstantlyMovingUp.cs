using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantlyMovingUp : MonoBehaviour
{
    [SerializeField] private float upMoveSpeed = 1f;
    [SerializeField] private float directionOfMovement = 1;

    private void FixedUpdate()
    {
        ForwardMovement();
    }

    private void ForwardMovement()
    {
        transform.position = transform.position + new Vector3(0, 0, directionOfMovement * upMoveSpeed * Time.deltaTime);
    }
}
