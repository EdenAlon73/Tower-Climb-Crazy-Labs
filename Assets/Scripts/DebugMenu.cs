using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DebugMenu : MonoBehaviour
{
    //Sliders
    private Slider gameSpeedSlider;
    private Slider playerRotationSlider;
    private Toggle accelerateOverTimeToggle;
    
    //Cache Ref
    private GravityModifier gravityModifier;
    private GameManager gameManager;
    
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gravityModifier = FindObjectOfType<GravityModifier>();
        gameSpeedSlider = GameObject.Find("Slider_GameSpeed").GetComponent<Slider>();
        playerRotationSlider = GameObject.Find("Slider_Player Rotation Speed").GetComponent<Slider>();
        accelerateOverTimeToggle = GameObject.Find("Toggle_Accelerate Over Time").GetComponent<Toggle>();
    }
  

    private void Update()
    {
        gameManager.gameTimeSpeed = gameSpeedSlider.value;
        gravityModifier.gravityRotationSpeed = playerRotationSlider.value;
        accelerateOverTimeToggle.isOn = gravityModifier.accelerateOverTime;
    }
}


