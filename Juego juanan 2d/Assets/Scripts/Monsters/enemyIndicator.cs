using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyIndicator : MonoBehaviour
{
    public Transform enemy;
    public Transform player;
    public SpriteRenderer indicador;
    public float awareMax = 10f,awareMin = 2;
    

    void Update()
    {
        if(enemy == null || player == null || indicador == null) return;

        float distanceToEnemy = Vector2.Distance(player.position, enemy.position);

        float alpha = Mathf.InverseLerp(awareMax, awareMin, distanceToEnemy);
        alpha = Mathf.Clamp01(alpha);

        Color color = indicador.color;
        color.a = alpha;
        indicador.color = color;

        Vector2 directon = (enemy.position - player.position).normalized;
        float angle = Mathf.Atan2(directon.y, directon.x) * Mathf.Rad2Deg;
        indicador.transform.rotation = Quaternion.Euler(0, 0, angle - 120);

        /*if(distanceToEnemy <= aware) 
        {
            indicador.SetActive(true);

            Vector2 directon =(enemy.position - player.position).normalized;

            float angle = Mathf.Atan2(directon.y, directon.x) * Mathf.Rad2Deg;

            indicador.transform.rotation = Quaternion.Euler(0,0,angle-120);
        }

        else
        {
            indicador.SetActive(false);
        }*/
    }
}
