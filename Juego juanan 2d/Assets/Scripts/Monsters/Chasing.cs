using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonoBehaviour
{

    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    public float _playerAwarenessDistance;


    public bool Aware = false;
    public Rigidbody2D monsrb;
    public float rota = 5f;
    AIDestinationSetter aiDestinationSetter;
    Transform player, point;


    private void Awake()
    {
        player = FindObjectOfType<movimiento>().transform;
    }



    void Start()
    {
        aiDestinationSetter = GetComponent<AIDestinationSetter>();
        player = GameObject.FindWithTag("Player").transform;
        point = GameObject.FindWithTag("Point").transform;
    }


    void Update()
    {

        Vector2 enemyToPlayerVector = player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;
        if (enemyToPlayerVector.magnitude <= _playerAwarenessDistance)
        {

            Aware = true;
        }
        else
        {
            Aware = false;
        }

        if (Aware)
        {
            aiDestinationSetter.target = player;
        }
        else
        {
            aiDestinationSetter.target = point;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, _playerAwarenessDistance);
    }
}
 
