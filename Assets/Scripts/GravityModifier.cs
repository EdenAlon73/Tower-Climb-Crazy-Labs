using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class GravityModifier : MonoBehaviour
{
    [Header("Movement Config")]
     public float climbingSpeed = 1f;
    [SerializeField] private float maxClimbingSpeed = 20f;
    [SerializeField] private float accelerationVarb = 1f;
    [SerializeField] private float maxAnimatorSpeed = 2f;
    [SerializeField] private float animAccelerationSpeed = 0.2f;
    public float gravityRotationSpeed = 150f;
    public float directionOfMovement = 1;
    private float horizontalInput;
    public bool isMoving;
    public bool accelerateOverTime = true;
    bool isDragging = false;
    
    
    //Cache Referances
    private Animator animator;
    

    private void Awake()
    {
        isMoving = true;
        animator = GetComponentInChildren<Animator>();
        animator.speed = 0.5f;
    }
    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
        }
    }

    void FixedUpdate()
    {
        ForwardMovement();
        AccelerateOverTime();
        HorizontalMovement();
       HorizontalMovementPhone();
    }

    private void ForwardMovement()
    {
        if (isMoving)
        {
            transform.position = transform.position + new Vector3(0, 0, directionOfMovement * climbingSpeed * Time.deltaTime); 
        }
    }
    
    private void HorizontalMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, -horizontalInput * gravityRotationSpeed * Time.deltaTime);
    }
    
    private void HorizontalMovementPhone()
    {
        if (isDragging)
        {
            float x = Input.GetAxis("Mouse X") * gravityRotationSpeed * Time.fixedDeltaTime;

            transform.Rotate(0, 0, -x * gravityRotationSpeed * Time.deltaTime);

        }
    }
   

    private void AccelerateOverTime()
    {
        if (accelerateOverTime)
        {
            if (climbingSpeed < maxClimbingSpeed)
            {
                climbingSpeed = climbingSpeed + accelerationVarb * Time.deltaTime;
                gravityRotationSpeed = gravityRotationSpeed + 2 * Time.deltaTime;
            }
            else
            {
                climbingSpeed = maxClimbingSpeed;
            }
        
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
}
