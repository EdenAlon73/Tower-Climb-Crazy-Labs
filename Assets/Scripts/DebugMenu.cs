using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DebugMenu : MonoBehaviour
{
    //Sliders
    private Slider playerRotationSlider;
    private Slider climbingSpeedSlider;
    private Toggle accelerateOverTimeToggle;
    private Slider obstacleSpeedSlider;
    //Cache Ref
    private GravityModifier gravityModifier;
    private GameManager gameManager;
    private SpawnerParent spikeBallSpawner;
    
    private void Awake()
    {
        
        spikeBallSpawner = FindObjectOfType<SpawnerParent>();
        gameManager = FindObjectOfType<GameManager>();
        gravityModifier = FindObjectOfType<GravityModifier>();
        playerRotationSlider = GameObject.Find("Slider_Player Rotation Speed").GetComponent<Slider>();
        climbingSpeedSlider = GameObject.Find("Slider_ClimbingSpeed").GetComponent<Slider>();
        accelerateOverTimeToggle = GameObject.Find("Toggle_Accelerate Over Time").GetComponent<Toggle>();
        obstacleSpeedSlider = GameObject.Find("Slider_SpikedBall Speed").GetComponent<Slider>();
    }
    private void Start()
    {
        playerRotationSlider.value = gravityModifier.gravityRotationSpeed;
        climbingSpeedSlider.value = gravityModifier.climbingSpeed;
        accelerateOverTimeToggle.isOn = gravityModifier.accelerateOverTime;
        obstacleSpeedSlider.value = spikeBallSpawner.fallingObstacleSpeed;
    }

    private void Update()
    {
        gravityModifier.gravityRotationSpeed = playerRotationSlider.value;
        gravityModifier.climbingSpeed = climbingSpeedSlider.value;
        gravityModifier.accelerateOverTime = accelerateOverTimeToggle.isOn;
        spikeBallSpawner.fallingObstacleSpeed = obstacleSpeedSlider.value;
    }

}


