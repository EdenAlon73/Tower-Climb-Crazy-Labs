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
    [SerializeField] private GameObject confettiFolder;
    [SerializeField] private GameObject brokenObastacle;
    [SerializeField] private GameObject jetPack;
    private bool hasJetPack = false;

    [SerializeField] private float jetpackActiveTime;
    private bool obstacleBroken;
    
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
            if (!hasJetPack)
            {
                Handheld.Vibrate();
                gravityModifier.directionOfMovement = -1;
                animator.SetBool("isFalling", true);
                transform.Rotate(-90, 0, 0 * Time.deltaTime * 400);
                playerCollider.enabled = false;
                sceneLoader.RestartLastLevel();
            }
            else
            {
                if (!obstacleBroken)
                {
                    obstacleBroken = true;
                    Instantiate(brokenObastacle, other.transform.position, other.transform.rotation);
                    Destroy(other.gameObject); 
                }
                
            }
        }

        if (other.CompareTag("Jetpack"))
        {
            hasJetPack = true;
            print("foundJetPack");
            jetPack.SetActive(true);
            transform.Rotate(-90, 0, 0 * Time.deltaTime * 400);
            animator.SetBool("isFlying", true);
            Invoke("BackToClimbing", jetpackActiveTime);
            Destroy(other.gameObject);
        }
        if (other.CompareTag("Confetti Collider"))
        {
            transform.Rotate(-90, 0, 0 * Time.deltaTime * 400);
            animator.SetBool("isFlying", true);
            confettiFolder.SetActive(true);
        }
        
        if (other.CompareTag("End Level"))
        {
            sceneLoader.LoadSceneByName("01Scene_End Scene");
        }
        
    }

    private void BackToClimbing()
    {
        hasJetPack = false;
        jetPack.SetActive(false);
        transform.Rotate(90, 0, 0 * Time.deltaTime * 400);
        animator.SetBool("isFlying", false);
    }
}
