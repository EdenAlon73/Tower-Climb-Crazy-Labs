using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject debugPanel;
    public float difficultySetting = 1;
    private GameObject woodenSpikesHolder1;
    private GameObject woodenSpikesHolder2;
    
    
    private void Awake()
    {
        woodenSpikesHolder1 = GameObject.Find("woodenSpikesHolder1");
        woodenSpikesHolder2 = GameObject.Find("woodenSpikesHolder2");
    }
    private void Start()
    {
        difficultySetting = 2f;
    }
    
    private void Update()
    {
        Difficulty();
    }
    private void Difficulty()
    {
        
        switch (difficultySetting)
        {
            case 1:
                woodenSpikesHolder1.SetActive(false);
                woodenSpikesHolder2.SetActive(true);
                break;
            case 2:
                woodenSpikesHolder1.SetActive(true);
                woodenSpikesHolder2.SetActive(false);
                break;
            case 3:
                woodenSpikesHolder1.SetActive(true);
                woodenSpikesHolder2.SetActive(true);
                break;
            default:
                print("setting not selected");
                break;
        }
    }
    
    public void ToggleDebugMenu()
    {
        if (gameIsPaused)
        {
            debugPanel.SetActive(false);
            Time.timeScale = 1f;
            gameIsPaused = false;
        }
        else
        {
            debugPanel.SetActive(true);
            Time.timeScale = 0f;
            gameIsPaused = true;
        }
    }

    
}
