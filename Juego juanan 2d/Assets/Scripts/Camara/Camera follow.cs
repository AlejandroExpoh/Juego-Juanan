using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Camerafollow : MonoBehaviour
{
    public BoxCollider2D bounds;
    private Func<Vector3> GetcameraFollowPositionFunc;
public void Setup(Func<Vector3> GetcameraFollowPositionFunc)
    {
        this.GetcameraFollowPositionFunc = GetcameraFollowPositionFunc;
    }

    public void SetGetCameraFollowPositionFunc(Func<Vector3> GetcameraFollowPositionFunc)
    {
       this.GetcameraFollowPositionFunc = GetcameraFollowPositionFunc;
    }
    void Update()
    {

        Vector3 cameraFollowPosition = GetcameraFollowPositionFunc();
        cameraFollowPosition.z = transform.position.z;

        Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
        float distance = Vector3.Distance(cameraFollowPosition, transform.position);
        float cameraMoveSpeed = 3f;


        if (distance > 0)
        {
            Vector3 newCameraPosition = transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;

            float distanceAfterMoving = Vector3.Distance(newCameraPosition, cameraFollowPosition);

            if (distanceAfterMoving > distance)
            {
                newCameraPosition = cameraFollowPosition;
            } 

            transform.position = newCameraPosition;

        }
        
        
    }
}
