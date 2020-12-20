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
    private Collider playerCollider;
    private SceneLoader sceneLoader;
    
    private void Awake()
    {
        gravityModifier = GetComponentInParent<GravityModifier>();
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponentInChildren<Animator>();
        playerCollider = GetComponent<CapsuleCollider>();
        sceneLoader = FindObjectOfType<SceneLoader>();
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
            playerCollider.enabled = false;
            sceneLoader.RestartLastLevel();
        }
        
        if (other.CompareTag("Finish"))
        {
            transform.Rotate(-90, 0, 0 * Time.deltaTime * 400);
            animator.SetBool("isFlying", true);
        }
        if (other.CompareTag("End Level"))
        {
            sceneLoader.LoadSceneByName("01Scene_End Scene");
        }
        
    }
}
