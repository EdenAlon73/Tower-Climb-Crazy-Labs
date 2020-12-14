using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragMovement : MonoBehaviour
{
 
    private Touch touch;
    [SerializeField] private float speedModifier;
    private float xPosMaxClamp = 17.5f;
    private float xPosMinClamp = -19.5f;
    //movement speed in units per second
    [SerializeField] private float movementSpeed = 5f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                var pos = transform.position;
                pos.x = Mathf.Clamp(transform.position.x, xPosMinClamp, xPosMaxClamp);
                transform.position = new Vector3(pos.x + touch.deltaPosition.x * speedModifier, 32.60001f, transform.position.z);
            }
        }
        tetingMovementArrows();
    }
    
  

    void tetingMovementArrows()
    {
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");

        //update the position
        transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime,
            0, 0);
    }
}




