using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DebugMenu : MonoBehaviour
{
 
    [Tooltip("Length Of Level In Seconds")]
    [SerializeField] private float gameSpeed;
    private GravityModifier gravityModifier;
    private Slider gameSpeedSlider;
  
    private bool triggeredLevelFinished = false;
    private GameManager gameManager;
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameSpeedSlider = GetComponentInChildren<Slider>();
        gravityModifier = FindObjectOfType<GravityModifier>();
    }
  

    private void Update()
    {
        print(gameSpeedSlider.value);
        gameManager.gameTimeSpeed = gameSpeedSlider.value;
    }
}


