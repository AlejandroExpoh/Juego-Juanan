using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Hiding : MonoBehaviour
{
    Chasing Chasing;
    public GameObject Enemigo;
    public bool escondido = false;
    [Header("Camara")]
    public Camera CamPrincipal;
    public float tiempo, cerca;
    float actual, normal;

    [Header("Luz")]
    public Transform aura;
    public float tamanyo;
    Vector3 descubierto, actualuz, cubierto;

    void Start()
    {
       Chasing = Enemigo.GetComponent<Chasing>();
        normal = CamPrincipal.orthographicSize;
        actual = normal;
        descubierto = aura.transform.localScale;
        actualuz = descubierto;
        cubierto = descubierto * tamanyo;
        
    }

   
    private void Update()
    {
        if (escondido)
        {
            Chasing._playerAwarenessDistance = 0;
            actual = cerca;
            actualuz = cubierto;
            
        }
        else
        {
            Chasing._playerAwarenessDistance =  30;
            actual = normal;
            actualuz = descubierto;
        }
        CamPrincipal.orthographicSize = Mathf.Lerp(CamPrincipal.orthographicSize, actual, tiempo * Time.deltaTime);
        aura.transform.localScale = Vector3.Lerp(aura.transform.localScale, actualuz, tiempo * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            escondido = true;
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            escondido = false;

        }
    }
}
