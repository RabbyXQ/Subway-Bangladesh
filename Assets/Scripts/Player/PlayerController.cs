using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float forwardSpeed;

    [SerializeField]
    private float laneDistance = 2; 
    [SerializeField]
    private float laneChangeSpeed = 5; 

    private CharacterController characterController;
    private Vector3 direction;

    private int desiredLane = 1; 
    private Vector3 targetLanePosition;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        direction = Vector3.zero;

        targetLanePosition = transform.position;
    }

    void Update()
    {
        direction.z = forwardSpeed;

        changeLane();

       
        characterController.Move(direction * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        
    }

    private void changeLane()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (desiredLane > 0)
            {
                moveLeft();
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (desiredLane < 2)
            {
                moveRight();
            }
        }

        Vector3 newPosition = Vector3.Lerp(transform.position, targetLanePosition, Time.deltaTime * laneChangeSpeed);
        newPosition.z = transform.position.z;
        characterController.Move(newPosition - transform.position);
    }

    private void moveLeft()
    {
      
        targetLanePosition = transform.position + Vector3.left * laneDistance;
        desiredLane--;
        Debug.Log("Moving Left to Lane: " + desiredLane);
    }

    private void moveRight()
    {
        
        targetLanePosition = transform.position + Vector3.right * laneDistance;
        desiredLane++;
        Debug.Log("Moving Right to Lane: " + desiredLane);
    }
}
