using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeInteractSalon : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    GameObject codePanel, PuertaFin, PuertaFinOpen, Niño, Joven, Adulto, Anciano;
    public static bool IsDoorOpened = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        codePanel.SetActive(false);
        Niño.SetActive(false);
        Joven.SetActive(false);
        Adulto.SetActive(false);
        Anciano.SetActive(false);
        PuertaFin.SetActive(true);
        PuertaFinOpen.SetActive(false);
    }


    void Update()
    {
        if (IsDoorOpened)
        {
            codePanel.SetActive(false);
            Niño.SetActive(false);
            Joven.SetActive(false);
            Adulto.SetActive(false);
            Anciano.SetActive(false);
            PuertaFin.SetActive(false);
            PuertaFinOpen.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Puzzle") && !IsDoorOpened)
        {
            codePanel.SetActive(true);
        }
        if (collision.gameObject.name.Equals("estatua1"))
        {
            Anciano.SetActive(true);
        }
        if (collision.gameObject.name.Equals("estatua2"))
        {
            Niño.SetActive(true);
        }
        if (collision.gameObject.name.Equals("estatua3"))
        {
            Adulto.SetActive(true);
        }
        if (collision.gameObject.name.Equals("estatua4"))
        {
            Joven.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Puzzle"))
        {
            codePanel.SetActive(false);
        }
        if (collision.gameObject.name.Equals("estatua1"))
        {
            Anciano.SetActive(false);
        }
        if (collision.gameObject.name.Equals("estatua2"))
        {
            Niño.SetActive(false);
        }
        if (collision.gameObject.name.Equals("estatua3"))
        {
            Adulto.SetActive(false);
        }
        if (collision.gameObject.name.Equals("estatua4"))
        {
            Joven.SetActive(false);
        }

    }


}
