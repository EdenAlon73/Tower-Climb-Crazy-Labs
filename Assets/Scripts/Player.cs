using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    // Cache Referances
    private GravityModifier gravityModifier;
    private GameManager gameManager;
    private Animator animator;
    private Collider collider;
    private void Awake()
    {
        gravityModifier = GetComponentInParent<GravityModifier>();
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponentInChildren<Animator>();
        collider = GetComponent<CapsuleCollider>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            gameManager.AddToScore();
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Obstacle"))
        {
            gravityModifier.directionOfMovement = -1;
            animator.SetBool("isFalling", true);
            transform.Rotate(-90, 0, 0 * Time.deltaTime * 400);
            collider.enabled = false;
        }
    }


    /*
    private void RotatePlayerY()
    {

        
       if (horizontalInput == 0)
       {
           if (transform.rotation.y < 0)
           {
               transform.Rotate(0, 1, 0);
           }
           if (transform.rotation.y > 0)
           {
               transform.Rotate(0, -1, 0);
           }
           print("transformRest");
       }

       playerEularY = transform.rotation.eulerAngles.y;
       
       if (playerEularY <= 80 || playerEularY >= 280)
       {
           print("i am here");
           if (horizontalInput > 0)
           {
               transform.Rotate(0,playerRotationSpeed * horizontalInput * Time.deltaTime, 0 );
           }
           if (horizontalInput < 0)
           {
               transform.Rotate(0, playerRotationSpeed * horizontalInput * Time.deltaTime, 0 );
           }
       }
       else if (playerEularY > 80f && playerEularY < 180f)
       {
           playerEularY = 70f;
           print("i am here 1");
       }
            
       else if (playerEularY < 80f && playerEularY > 180f)
       {
           playerEularY = 290f;
           print("i am here 2");
       }
       
       
       playerEularY = transform.rotation.eulerAngles.y;
       float horizontalInput = Input.GetAxis("Horizontal");
       
       if (playerEularY <= 50f || playerEularY >= 310f)
       {
           if (horizontalInput < 0 )
           {
               playerEularY -= turningSpeed;
              
           }
       
           if (horizontalInput > 0)
           {
               playerEularY += turningSpeed;
               
           }
       }
        
       else if (playerEularY > 50f && playerEularY < 180f)
       {
           playerEularY = 49.9f;
       }
        
       else if (playerEularY < 310f && playerEularY > 180f)
       {
           playerEularY = 310.1f;
       }
        
       transform.rotation = Quaternion.Euler(0f, playerEularY, 0f);
       
       
       print(playerEularY);

    }
    */
}
