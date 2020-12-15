using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    [Header("Movement Config")]
    [SerializeField] private float upMoveSpeed = 1f;
    [SerializeField] private float directionOfMovement = 1;
    [SerializeField] private float accelerationVarb = 1f;
    [SerializeField] private float maxAnimatorSpeed = 2f;
    [SerializeField] private float animAccelerationSpeed = 0.2f;
    public bool isMoving;
    private float maxMoveSpeed = 20f;
    private float rotationMax = 0f;
    
    
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
    private void Start()
    {
        Mathf.Clamp(rotationMax, -18f, 18f);
        
    }
    void FixedUpdate()
    {
        ForwardMovement();
        HorizontalMovement();
        Accelerate();
        SetAnimationSpeed();
        RotatePlayerY();
        RotateInFrame();
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
        float horizontalInput = Input.GetAxis("Horizontal");
        
        //update the rotation = position
        transform.Rotate(0, 0, -horizontalInput * player.playerRotationSpeed * Time.deltaTime);
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

    private void RotatePlayerY()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Horizontal") == 0)
        {
            //player.transform.rotation = Quaternion.Lerp(player.transform.rotation, ogTransofrm, Time.deltaTime * 10);
            //player.transform.Rotate(ogTransofrm.rotation);
            if (player.transform.rotation.y < 0)
            {
                player.transform.Rotate(0, 1, 0);
            }
            if (player.transform.rotation.y > 0)
            {
                player.transform.Rotate(0, -1, 0);
            }
            print("transformRest");
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            player.transform.Rotate(0, horizontalInput, 0 * player.playerRotationSpeed * Time.deltaTime);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
           player.transform.Rotate(0, horizontalInput, 0 * player.playerRotationSpeed * Time.deltaTime);
        }
    }
    float ClampAngle(float angle, float from, float to)
    {
        // accepts e.g. -80, 80
        if (angle < 0f) angle = 360 + angle;
        if (angle > 180f) return Mathf.Max(angle, 360 + from);
        return Mathf.Min(angle, to);
    }


    void RotateInFrame()
    {
       // if (!Input.GetMouseButton(1)) return; // RMB down


        float mx = Input.GetAxis("Horizontal") * Time.deltaTime * player.playerRotationSpeed;
        float my = Input.GetAxis("Vertical") * Time.deltaTime * player.playerRotationSpeed;

        Vector3 rot = transform.rotation.eulerAngles + new Vector3(-my, mx, 0f); //use local if your char is not always oriented Vector3.up
        rot.x = ClampAngle(rot.x, -60f, 60f);

        transform.eulerAngles = rot;
    }
}
