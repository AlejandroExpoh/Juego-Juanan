using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeInteract : MonoBehaviour
{
   Rigidbody2D rb;
    [SerializeField]
    GameObject codePanel, PuertaFin, PuertaFinOpen;
    public static bool IsDoorOpened = false;
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        codePanel.SetActive(false);
        PuertaFin.SetActive(true);
        PuertaFinOpen.SetActive(false);
    }

    
    void Update()
    {
        if (IsDoorOpened)
        {
            codePanel.SetActive(false);
            PuertaFin.SetActive(false);
            PuertaFinOpen.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals ("Door") && !IsDoorOpened)
        {
            codePanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Door"))
        {
            codePanel.SetActive(false);
        }
    }




}
