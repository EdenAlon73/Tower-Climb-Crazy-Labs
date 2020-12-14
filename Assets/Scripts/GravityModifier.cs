using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityModifier : MonoBehaviour
{
    [Header("Movement Config")]
    [SerializeField] private float upMoveSpeed = 1f;
    [SerializeField] private float directionOfMovement = 1;
    public bool isMoving;
    
    //Cache Referances
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        isMoving = true;
    }
    
    void FixedUpdate()
    {
        ForwardMovement();
        HorizontalMovement();
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
        transform.Rotate(0, 0, horizontalInput * player.playerRotationSpeed * Time.deltaTime);
    }
}
