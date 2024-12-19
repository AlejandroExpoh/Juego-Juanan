using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeInteract : MonoBehaviour
{
   Rigidbody2D rb;
    [SerializeField]
    GameObject codePanel, PuertaFin, PuertaFinOpen, Panel;
    public static bool IsDoorOpened = false;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        codePanel.SetActive(false);
        Panel.SetActive(false);
        PuertaFin.SetActive(true);
        PuertaFinOpen.SetActive(false);
    }

    
    void Update()
    {
        if (IsDoorOpened)
        {
            codePanel.SetActive(false);
            Panel.SetActive(false);
            PuertaFin.SetActive(false);
            PuertaFinOpen.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals ("Puzzle") && !IsDoorOpened)
        {
            codePanel.SetActive(true);
        }
        if (collision.gameObject.name.Equals("Periodico"))
        {
            Panel.SetActive(true);
        }
        if (collision.gameObject.name.Equals("Periodico"))
        {
            Panel.SetActive(true);
        }
        if (collision.gameObject.name.Equals("Periodico"))
        {
            Panel.SetActive(true);
        }
        if (collision.gameObject.name.Equals("Periodico"))
        {
            Panel.SetActive(true);
        }
        if (collision.gameObject.name.Equals("Periodico"))
        {
            Panel.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Puzzle"))
        {
            codePanel.SetActive(false);
        }
        if (collision.gameObject.name.Equals("Periodico"))
        {
            Panel.SetActive(false);
        }
    }

    
        }
    



