using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    
    [SerializeField] private int pointsPerCoinCollected = 1;
    [SerializeField] private int currentScore = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    private void Awake()
    {
        currentScore = 0;
    }
    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }
    public void AddToScore()
    {
        currentScore = currentScore + pointsPerCoinCollected;
        scoreText.text = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
    
}