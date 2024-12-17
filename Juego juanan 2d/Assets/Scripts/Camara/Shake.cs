using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Shake : MonoBehaviour
{
    public Transform enemy;
    public Transform player;
    public Camera mainCamenra;
    public float maxDistance = 10f;
    public float minDistance = 2f;
    public float maxShake = 0.5f;
    public float maxPulse = 10f;

    Vector3 initialPos;
    float shakeCant;

    private void Start()
    {
        if(mainCamenra == null) 
        {
            mainCamenra = Camera.main;
        }
        initialPos = mainCamenra.transform.localPosition;
    }

    private void Update()
    {
        if (enemy == null || player == null) return;

        float distanceToEnemy = Vector2.Distance(player.position, enemy.position);

        float intensidad = Mathf.InverseLerp(maxDistance, minDistance, distanceToEnemy);
        shakeCant = intensidad * maxShake;

        mainCamenra.transform.localPosition = initialPos + Random.insideUnitSphere * shakeCant;

        float pulseSpeed = Mathf.Lerp(0, maxPulse, intensidad);
        mainCamenra.fieldOfView = 60 + Mathf.Sin(Time.time * pulseSpeed) * (intensidad*5);
    }

    private void OnDisable()
    {
        if(mainCamenra != null)
        {
            mainCamenra.transform.localPosition = initialPos;
        }
    }

}
