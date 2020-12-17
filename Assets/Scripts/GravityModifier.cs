using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class GravityModifier : MonoBehaviour
{
    [Header("Movement Config")]
     public float climbingSpeed = 1f;
    [SerializeField] private float maxMoveSpeed = 20f;
    [SerializeField] private float accelerationVarb = 1f;
    [SerializeField] private float maxAnimatorSpeed = 2f;
    [SerializeField] private float animAccelerationSpeed = 0.2f;
    public float gravityRotationSpeed = 150f;
    public float directionOfMovement = 1;
    private float horizontalInput;
    public bool isMoving;
    public bool accelerateOverTime = true;
    private float zPosMaxClamp = 25;
    private float zPosMinClamp = -25;
    
    
    
    //Cache Referances
    private Player player;
    private Animator animator;
    private Touch touch;
    

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
        AccelerateOverTime();
       // HorizontalMovement();
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
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                var pos = transform.rotation;
                pos.z = Mathf.Clamp(transform.position.z, zPosMinClamp, zPosMaxClamp);
                transform.Rotate(0, 0, pos.z + touch.deltaPosition.x * gravityRotationSpeed * Time.deltaTime);
                //transform.Rotate(); = new Vector3(pos.x + touch.deltaPosition.x * gravityRotationSpeed, 32.60001f, transform.position.z);
            }
        } 
    }
    

   
    private void AccelerateOverTime()
    {
        if (accelerateOverTime)
        {
            if (climbingSpeed < maxMoveSpeed)
            {
                climbingSpeed = climbingSpeed + accelerationVarb * Time.deltaTime;
                gravityRotationSpeed = gravityRotationSpeed + 2 * Time.deltaTime;
            }
            else
            {
                climbingSpeed = maxMoveSpeed;
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
