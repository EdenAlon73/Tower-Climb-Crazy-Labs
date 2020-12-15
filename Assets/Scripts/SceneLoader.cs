using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float delayInSeconds = 1f;
    [SerializeField] private Button[] levelButtons;
    private GameManager gameManager;
    
   
    // --------------------- Methods --------------------
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        CheckLevelUnlocked();
    }

    private void CheckLevelUnlocked()
    {
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    

    public void LoadSceneByName(string nameofSceneToLoad)
    {
        StartCoroutine(SceneNameCor(nameofSceneToLoad));
        if (gameManager != null)
        {
            gameManager.ResetGame();
        }
    }
    
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevelCor(SceneManager.GetActiveScene().buildIndex + 1));
        if (gameManager != null)
        {
            gameManager.ResetGame();
        }
    }
    
    public void RestartLastLevel()
    {
        
        StartCoroutine(LoadLevelCor(SceneManager.GetActiveScene().buildIndex));
        if (gameManager != null)
        {
              gameManager.ResetGame();
        }
    }
    
    
    // ----------------------- Coroutines ----------------------
    
    IEnumerator LoadLevelCor(int levelIndex)
    {
        yield return new WaitForSecondsRealtime(delayInSeconds);
        SceneManager.LoadScene(levelIndex);
    }

    IEnumerator SceneNameCor(string nameofSceneToLoad)
    {
        yield return new WaitForSecondsRealtime(delayInSeconds);
        SceneManager.LoadScene(nameofSceneToLoad);
    }
    
}