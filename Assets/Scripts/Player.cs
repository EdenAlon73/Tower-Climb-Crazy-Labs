using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Player : MonoBehaviour
{
    
    // Cache Referances
    private GravityModifier gravityModifier;
    private GameManager gameManager;
    private Animator animator;
    private Collider playerCollider;
    private SceneLoader sceneLoader;
    private CapsuleCollider capsuleCollider;
    [SerializeField] private GameObject confettiFolder;
    [SerializeField] private GameObject brokenObastacle;
    [SerializeField] private GameObject brokenFallingObstacle;
    [SerializeField] private GameObject jetPack;
    public bool hasJetPack = false;
    private bool isFalling = false;
    private bool playerXRotIsZero = true;
    private Vector3 playerFlyingCollPos;
    private Vector3 playerOgCollPos;
    [SerializeField] private float jetpackActiveTime;
    private bool obstacleBroken;
    [SerializeField] CinemachineVirtualCamera cinemachine;

    private void Awake()
    {
        gravityModifier = GetComponentInParent<GravityModifier>();
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponentInChildren<Animator>();
        playerCollider = GetComponent<CapsuleCollider>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        playerFlyingCollPos = new Vector3(-0.07324244f, -1.42f, -0.41f);
        playerOgCollPos = new Vector3(-0.07324244f, -0.6294356f, -0.02116803f);
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
            if (!hasJetPack && !isFalling)
            {
                Handheld.Vibrate();
                gravityModifier.directionOfMovement = -1;
                animator.SetBool("isFalling", true);
                transform.Rotate(-90, 0, 0 * Time.deltaTime * 400);
                isFalling = true;
                playerXRotIsZero = false;
                

                //playerCollider.enabled = false;
                // sceneLoader.RestartLastLevel();
            }
            else
            {
                if (!obstacleBroken)
                {
                    gameManager.AddToScoreObstacle();
                    Instantiate(brokenObastacle, other.transform.position, other.transform.rotation);
                    Destroy(other.gameObject);
                    Invoke("SetObstacleBrokenToFalse", 0.5f);
                }

            }
        }
        if (other.CompareTag("FallingObstacle"))
        {
            if (!hasJetPack && !isFalling)
            {
                capsuleCollider.center = playerOgCollPos;
                Handheld.Vibrate();
                gravityModifier.directionOfMovement = -1;
                animator.SetBool("isFalling", true);
                transform.Rotate(-90, 0, 0 * Time.deltaTime * 400);
                isFalling = true;
                playerXRotIsZero = false;

                //playerCollider.enabled = false;
                // sceneLoader.RestartLastLevel();
            }
            else
            {
                if (!obstacleBroken)
                {
                    gameManager.AddToScoreObstacle();
                    obstacleBroken = true;
                    Instantiate(brokenFallingObstacle, other.transform.position, transform.rotation);
                    Destroy(other.gameObject);
                    Invoke("SetObstacleBrokenToFalse", 0.5f);
                }

            }
        }

        if (other.CompareTag("Jetpack"))
        {
            capsuleCollider.center = playerFlyingCollPos;
            isFalling = false;
            gravityModifier.directionOfMovement = 1;
            hasJetPack = true;
            print("foundJetPack");
            jetPack.SetActive(true);
            animator.SetBool("isFlying", true);
            animator.SetBool("isFalling", false);
            Invoke("BackToClimbing", jetpackActiveTime);
            Destroy(other.gameObject);
            if (!playerXRotIsZero)
            {
                transform.Rotate(0, 0, 0 * Time.deltaTime * 400);
            }
            else
            {
                transform.Rotate(-90, 0, 0 * Time.deltaTime * 400);
            }
        }
        if (other.CompareTag("Confetti Collider"))
        {
            capsuleCollider.center = playerFlyingCollPos;
            transform.Rotate(-90, 0, 0 * Time.deltaTime * 400);
            animator.SetBool("isFlying", true);
            jetPack.SetActive(true);
            confettiFolder.SetActive(true);
        }
        
        if (other.CompareTag("End Level"))
        {
            sceneLoader.LoadSceneByName("01Scene_End Scene");
        }
        
    }

    private void BackToClimbing()
    {
        capsuleCollider.center = playerOgCollPos;
        hasJetPack = false;
        jetPack.SetActive(false);
        transform.Rotate(90, 0, 0 * Time.deltaTime * 400);
        animator.SetBool("isFlying", false);
    }

    private void SetObstacleBrokenToFalse()
    {
        obstacleBroken = false;
    }

    private void LevelLost()
    {
       
    }
}
