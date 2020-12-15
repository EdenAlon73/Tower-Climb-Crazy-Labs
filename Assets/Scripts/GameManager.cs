using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Range(0.1f, 2f)] [SerializeField] private float gameTimeSpeed = 1f;
    
    [SerializeField] private int pointsPerCoinCollected = 20;
    [SerializeField] private int currentScore = 0;
    [SerializeField] private TextMeshProUGUI scoreText;


    private void Awake()
    {
      SetUpSingleton();  
    }

    private void SetUpSingleton()
    {
        int gameMangerCount = FindObjectsOfType<GameManager>().Length;
        if (gameMangerCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    void Update()
    {
        Time.timeScale = gameTimeSpeed;
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