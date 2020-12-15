using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    [Header("Movement Config")]
    [SerializeField] public float upMoveSpeed = 1f;
    [SerializeField] private float directionOfMovement = 1;
    [SerializeField] private float accelerationVarb = 1f;
    [SerializeField] private float maxAnimatorSpeed = 2f;
    [SerializeField] private float animAccelerationSpeed = 0.2f;
    [SerializeField] private float gravityRotationSpeed = 150f;
    [SerializeField] private float turningSpeed = 5f;
    private float horizontalInput;
    public bool isMoving;
    private float maxMoveSpeed = 20f;
    
    
    //Cache Referances
    private Player player;
    private Animator animator;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        isMoving = true;
        animator = GetComponentInChildren<Animator>();
        animator.speed = 0.5f;
    }
    
    void FixedUpdate()
    {
        ForwardMovement();
        HorizontalMovement();
        Accelerate();
        SetAnimationSpeed();
    }

    private void ForwardMovement()
    {
        if (isMoving)
        {
            transform.position = transform.position + new Vector3(0, 0, directionOfMovement * upMoveSpeed * Time.deltaTime); 
        }
    }
    private void HorizontalMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, -horizontalInput * gravityRotationSpeed * Time.deltaTime);
    }
    
    private void Accelerate()
    {
        if (upMoveSpeed < maxMoveSpeed)
        {
            upMoveSpeed = upMoveSpeed + accelerationVarb * Time.deltaTime;
            player.playerRotationSpeed = player.playerRotationSpeed + 2 * Time.deltaTime;
        }
        else
        {
            upMoveSpeed = maxMoveSpeed;
        }
    
    }

    private void SetAnimationSpeed()
    {
        if (animator.speed < maxAnimatorSpeed)
        {
            animator.speed = animator.speed + animAccelerationSpeed * Time.deltaTime ;
        }
        else
        {
            animator.speed = maxAnimatorSpeed;
        }
        
    }
}
