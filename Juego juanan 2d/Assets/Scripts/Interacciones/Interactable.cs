using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode InteractKey;
    public UnityEvent interactAction;
    void Start()
    {
        
    }


    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(InteractKey))
            {
                interactAction.Invoke();

            }

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player esta en posición");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInRange = false;
        Debug.Log("Player no esta en posición");
    }

    
}
