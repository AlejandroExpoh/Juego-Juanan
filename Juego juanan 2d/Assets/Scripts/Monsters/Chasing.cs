using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chasing : MonoBehaviour
{

    public bool AwareOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }

    [SerializeField]
    public float _playerAwarenessDistance;

    [Header("Variables")]
    public bool Aware = false;
    public Rigidbody2D monsrb;
    public float rota = 5f;
    [Header("Variables2")]
    public Animator animator;
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

        if(monsrb.position.x != 0 || monsrb.position.y != 0)
        {
            animator.SetBool("andar", true);
        }
        else
        {
            animator.SetBool("andar", false);
        }

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
    
}
 
