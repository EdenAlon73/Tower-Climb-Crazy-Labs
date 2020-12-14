using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField]float moveSpeed = 1f;
    [SerializeField] Rigidbody rb;
    [SerializeField] Transform Tower;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] GameObject self;
    [SerializeField] float rotationSpeed = 5f;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        self = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        moveSpeed = 1;
    }
    private void Update()
    {
        ClimbUp();
        Accelerate();
        SetGravity();
    }


    private void ClimbUp()
    {
        rb.velocity = transform.up * moveSpeed;
    }

    private void Accelerate()
    {
        moveSpeed =moveSpeed + 1f * Time.deltaTime;
    }

    private void SetGravity()
    {
        rb.AddForce((self.transform.position - Tower.position).normalized * gravity);
        self.transform.rotation = Quaternion.Slerp(self.transform.rotation, Quaternion.FromToRotation(self.transform.up, (self.transform.position - Tower.position).normalized)
            * self.transform.rotation, rotationSpeed * Time.deltaTime);
    }

  
}
