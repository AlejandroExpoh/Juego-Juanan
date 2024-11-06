using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Camerafollow : MonoBehaviour
{
private Func<Vector3> GetcameraFollowPositionFunc;
public void Setup(Func<Vector3> GetcameraFollowPositionFunc)
    {
        this.GetcameraFollowPositionFunc = GetcameraFollowPositionFunc;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraFollowPosition = GetcameraFollowPositionFunc();
        cameraFollowPosition.z = transform.position.z;
        transform.position = cameraFollowPosition;
        
    }
}
