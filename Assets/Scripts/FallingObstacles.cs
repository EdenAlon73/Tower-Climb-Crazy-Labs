using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacles : MonoBehaviour
{
    [SerializeField] private float fallSpeed = 2f;
    private float directionOfMovement = -1;
    [SerializeField] float delayInSeconds = 0.3f;

    bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ForwardMovement();
    }

    private void ForwardMovement()
    {
        transform.position = transform.position + new Vector3(0, 0, directionOfMovement * fallSpeed * Time.deltaTime);
    }

  
}
    
