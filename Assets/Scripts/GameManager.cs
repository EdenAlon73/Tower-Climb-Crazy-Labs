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
        scoreText = FindObjectOfType<TextMeshProUGUI>();
    }
    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }
    public void AddToScore()
    {
        currentScore = currentScore + pointsPerCoinCollected;
        scoreText.text = currentScore.ToString();
        StartCoroutine(ScorePulse());
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    private IEnumerator ScorePulse()
    {
        for (float i = 1f; i <= 2f; i += 0.05f)
        {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        scoreText.rectTransform.localScale = new Vector3(2f, 2f, 2f);
        
        for (float i = 2f; i >= 1f ; i -= 0.05f)
        {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        scoreText.rectTransform.localScale = new Vector3(1, 1, 1);
        
    }
    
}