using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{

    public bool isChasing = false;
    public Rigidbody2D monsrb;
    public float rota = 5f;
    AIDestinationSetter aiDestinationSetter;
    Transform player, point;
    [SerializeField] private FOV FOV;
 
    void Start()
    {
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
        player = GameObject.FindWithTag("Player").transform;
        point = GameObject.FindWithTag("Point").transform;
    } 

    
    void Update()
    {
        if (isChasing)
        {
            aiDestinationSetter.target = player;
        }
        else 
        {
            aiDestinationSetter.target = point;
        }

        

    }
    void FixedUpdate()
    {
        FOV.SetOrigin(transform.position);
        Vector2 direction = transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        monsrb.rotation = angle;
        FOV.SetAimDirection(direction);
        
    }
}
