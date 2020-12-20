using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideIcon : MonoBehaviour
{
    public static SlideIcon instance;
    
    private void Awake()
    {
        if (instance == null)
        {    
            instance = this;        
        }
        else
        {
            Destroy(gameObject);    
            return;                
        }
        DontDestroyOnLoad(gameObject);
    }
}
