using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class PlayerHC : MonoBehaviour
{
    
    // Cache Referances
    private GravityModifier gravityModifier;
    private GameManager gameManager;
    private Animator animator;
    private SceneLoader sceneLoader;
    private CapsuleCollider capsuleCollider;
    
    // Jetpack
    [SerializeField] private GameObject jetpackOnPlayer;
    public bool hasJetPack = false;
    [SerializeField] private float jetpackActiveTime;
    
    // Game Objects
    [SerializeField] private GameObject confettiFolder;
    [SerializeField] private GameObject brokenObastacle;
    [SerializeField] private GameObject crackedSpikeballObstacle;
    [SerializeField] private GameObject crackedVendingMachine;
    [SerializeField] private GameObject crackedCar;
    [SerializeField] private GameObject spikeballSpawnPoint;

    // Bool's
    private bool isFalling = false;
    private bool obstacleBroken;
    
    //Transforms
    private Vector3 ogTransformRotation;
    private Vector3 flyingTransformRotation;
    private Vector3 fallingTransformRotation;

    private void Awake()
    {
        gravityModifier = GetComponentInParent<GravityModifier>();
        gameManager = FindObjectOfType<GameManager>();
        animator = GetComponentInChildren<Animator>();
        sceneLoader = FindObjectOfType<SceneLoader>();
        capsuleCollider = GetComponentInChildren<CapsuleCollider>();
        
        
        ogTransformRotation = new Vector3(87.57f, 0.657f, -0.657f);
        flyingTransformRotation = new Vector3(-3.82f, 0.657f, -0.657f);
        fallingTransformRotation = new Vector3(-70.429f, 0.37849f, 0.37849f);
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
                SetToFallingRotation();
                isFalling = true;
                
                // sceneLoader.RestartLastLevel();
            }
            else
            {
                if (!obstacleBroken)
                {
                    obstacleBroken = true;
                    gameManager.AddToScoreObstacle();
                    Instantiate(brokenObastacle, other.transform.position, other.transform.rotation);
                    Destroy(other.gameObject);
                    Invoke("SetObstacleBrokenToFalse", 0.5f);
                }

            }
        }
        if (other.CompareTag("FallingObstacle") || other.CompareTag("FallingVending") || other.CompareTag("FallingCar"))
        {
            if (!hasJetPack && !isFalling)
            {
                Handheld.Vibrate();
                gravityModifier.directionOfMovement = -1;
                animator.SetBool("isFalling", true);
                SetToFallingRotation();
                isFalling = true;
                
                // sceneLoader.RestartLastLevel();
            }
            else
            {
                if (!obstacleBroken)
                {
                    gameManager.AddToScoreObstacle();
                    obstacleBroken = true;
                    Destroy(other.gameObject);
                    Invoke("SetObstacleBrokenToFalse", 0.5f);
                    if (other.CompareTag("FallingObstacle"))
                    {
                        Instantiate(crackedSpikeballObstacle, spikeballSpawnPoint.transform.position, spikeballSpawnPoint.transform.rotation);
                    }

                    if (other.CompareTag("FallingVending"))
                    {
                        Instantiate(crackedVendingMachine, other.transform.position, other.transform.rotation);
                    }
                }

            }
        }

        if (other.CompareTag("Jetpack"))
        {
            gravityModifier.directionOfMovement = 1;
            isFalling = false;
            hasJetPack = true;
            jetpackOnPlayer.SetActive(true);
            animator.SetBool("isFlying", true);
            animator.SetBool("isFalling", false);
            Invoke("BackToClimbing", jetpackActiveTime);
            Destroy(other.gameObject);
            SetToFlyingRotation();
        }
        if (other.CompareTag("Confetti Collider"))
        {
            SetToFlyingRotation();
            animator.SetBool("isFlying", true);
            jetpackOnPlayer.SetActive(true);
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
        jetpackOnPlayer.SetActive(false);
        SetToClimbingRotation();
       // transform.Rotate(90, 0, 0 * Time.deltaTime * 400);
        animator.SetBool("isFlying", false);
    }

    private void SetToClimbingRotation()
    {
        transform.localRotation = Quaternion.Euler(ogTransformRotation.x, ogTransformRotation.y, ogTransformRotation.z);
    }

    private void SetToFlyingRotation()
    {
        transform.localRotation = Quaternion.Euler(flyingTransformRotation.x, flyingTransformRotation.y, flyingTransformRotation.z);
    }

    private void SetToFallingRotation()
    {
        transform.localRotation = Quaternion.Euler(fallingTransformRotation.x, fallingTransformRotation.y, fallingTransformRotation.z);
    }

    private void SetObstacleBrokenToFalse()
    {
        obstacleBroken = false;
    }
}
