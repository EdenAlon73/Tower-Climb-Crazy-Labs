using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject debugPanel;

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
