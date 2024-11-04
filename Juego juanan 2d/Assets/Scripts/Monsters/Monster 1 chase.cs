using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Monster1chase : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    private bool isFacingRight = true;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);


        bool isPlayerRight = transform.position.x < player.position.x;
        Flip(isPlayerRight);
    }


    private void Flip(bool isPlayerRight)
    {
        if((isFacingRight && !isPlayerRight) || (!isFacingRight && isPlayerRight))
        {
            isFacingRight = !isFacingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }

    }

}
