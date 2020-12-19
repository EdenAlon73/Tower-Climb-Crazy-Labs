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
    private Slider obstacleSpeedSlider;
    private Slider obstacleSpawnRateSlider;
    private Slider difficultySlider;

    //Toggles
    private Toggle accelerateOverTimeToggle;
    private Toggle increaseObstacleSpawningToggle;

    //Cache Ref
    private GravityModifier gravityModifier;
    private SpawnerParent spawnerParent;
    private CanvasController canvasController;
    
    private void Awake()
    {
        //Cache Ref
        spawnerParent = FindObjectOfType<SpawnerParent>();
        gravityModifier = FindObjectOfType<GravityModifier>();
        canvasController = GetComponentInParent<CanvasController>();
        //Sliders
        playerRotationSlider = GameObject.Find("Slider_Player Rotation Speed").GetComponent<Slider>();
        climbingSpeedSlider = GameObject.Find("Slider_ClimbingSpeed").GetComponent<Slider>();
        obstacleSpeedSlider = GameObject.Find("Slider_Falling Obstacle Speed").GetComponent<Slider>();
        obstacleSpawnRateSlider = GameObject.Find("Slider_Obstacle Spawn Rate").GetComponent<Slider>();
        difficultySlider = GameObject.Find("Slider_DifficultySetting").GetComponent<Slider>();

        //Toggles
        accelerateOverTimeToggle = GameObject.Find("Toggle_Accelerate Over Time").GetComponent<Toggle>();
        increaseObstacleSpawningToggle = GameObject.Find("Toggle_Increase Obstacle Spawning").GetComponent<Toggle>();
    }
    private void Start()
    {
        //Sliders
        playerRotationSlider.value = gravityModifier.gravityRotationSpeed;
        climbingSpeedSlider.value = gravityModifier.climbingSpeed;
        obstacleSpeedSlider.value = spawnerParent.fallingObstacleSpeed;
        obstacleSpawnRateSlider.value = spawnerParent.maxSpawnDelay;
        difficultySlider.value = canvasController.difficultySetting;
        //Toggles
        accelerateOverTimeToggle.isOn = gravityModifier.accelerateOverTime;
        increaseObstacleSpawningToggle.isOn = spawnerParent.doISpawnOverTime;
    }

    private void Update()
    {
        //Sliders
        gravityModifier.gravityRotationSpeed = playerRotationSlider.value;
        gravityModifier.climbingSpeed = climbingSpeedSlider.value;
        spawnerParent.fallingObstacleSpeed = obstacleSpeedSlider.value;
        spawnerParent.maxSpawnDelay = obstacleSpawnRateSlider.value;
        canvasController.difficultySetting = difficultySlider.value;
        //Toggles
        gravityModifier.accelerateOverTime = accelerateOverTimeToggle.isOn;
        spawnerParent.doISpawnOverTime = increaseObstacleSpawningToggle.isOn;
        
    }

  


}


