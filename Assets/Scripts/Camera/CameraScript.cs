using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField]
    private Transform player; 
    [SerializeField]
    private Vector3 offset; 
    [SerializeField]
    private float followSpeed = 5f;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player transform not assigned in the CameraFollower script.");
        }else{
            offset = transform.position - player.position;
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
           
            Vector3 targetPosition = player.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }
}
