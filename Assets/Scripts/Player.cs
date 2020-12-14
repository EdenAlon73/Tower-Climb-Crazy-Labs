using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GravityModifier gravityModifier;
    
    [Header("Movement Config")]
    public float playerRotationSpeed = 250f;

    private void Awake()
    {
        gravityModifier = GetComponentInParent<GravityModifier>();
    }

}
