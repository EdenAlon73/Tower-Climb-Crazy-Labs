using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    [Header("Movement Config")]
    public float climbingSpeed = 1f;
    [SerializeField] private float maxClimbingSpeed = 20f;
    [SerializeField] private float accelerationVarb = 1f;
    [SerializeField] private float maxAnimatorSpeed = 2f;
    [SerializeField] private float animAccelerationSpeed = 0.2f;
    [SerializeField] private float jetpackSpeedValue;
    public float gravityRotationSpeed = 150f;
    public float directionOfMovement = 1;
    private float horizontalInput;
    private bool isDragging = false;
    public bool isMoving;
    public bool accelerateOverTime = true;
    private float jetpackSpeedBoost;
    
    
    //Cache Referances
    private Animator animator;
    private PlayerHC playerHcScript;
    

    private void Awake()
    {
        isMoving = true;
        animator = GetComponentInChildren<Animator>();
        playerHcScript = GetComponentInChildren<PlayerHC>();
        animator.speed = 1f;
        jetpackSpeedBoost = 0f;
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
        HorizontalMovementPhone();
        HorizontalMovement();
        AccelerateWithJetpack();
        
    }

    private void ForwardMovement()
    {
        if (isMoving)
        {
            transform.position = transform.position + new Vector3(0, 0, directionOfMovement * (climbingSpeed + jetpackSpeedBoost) * Time.deltaTime); 
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

    private void AccelerateWithJetpack()
    {
        if (playerHcScript.hasJetPack)
        {
            jetpackSpeedBoost = jetpackSpeedValue;
        }
        else
        {
            jetpackSpeedBoost = 0f;
        }
    }
    
}
