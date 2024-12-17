using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Camerafollow : MonoBehaviour
{
    public BoxCollider2D bounds;
    private Func<Vector3> GetcameraFollowPositionFunc;

    [Header("Shake")]
    public Transform enemy;
    public Transform player;
    public float maxDistance = 10f;
    public float minDistance = 2f;
    public float maxShake = 0.5f;
    public float maxPulse = 10f;

    Vector3 initialPos;
    float shakeCant;

    public void Setup(Func<Vector3> GetcameraFollowPositionFunc)
    {
        this.GetcameraFollowPositionFunc = GetcameraFollowPositionFunc;
    }

    public void SetGetCameraFollowPositionFunc(Func<Vector3> GetcameraFollowPositionFunc)
    {
       this.GetcameraFollowPositionFunc = GetcameraFollowPositionFunc;
    }

    private void Start()
    {
        initialPos = transform.position;
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

        if (enemy == null || player == null) return;

        float distanceToEnemy = Vector2.Distance(player.position, enemy.position);
        float intensidad = Mathf.InverseLerp(maxDistance, minDistance, distanceToEnemy);
        shakeCant = intensidad * maxShake;

        //transform.position += initialPos + (Vector3)UnityEngine.Random.insideUnitSphere * shakeCant;
        

        float pulseSpeed = Mathf.Lerp(0, maxPulse, intensidad);
        Camera.main.fieldOfView = 60 + Mathf.Sin(Time.time * pulseSpeed) * (intensidad * 5);
    }
    private void OnDisable()
    {
        transform.position = initialPos;
        Camera.main.fieldOfView = 60;
    }
}
