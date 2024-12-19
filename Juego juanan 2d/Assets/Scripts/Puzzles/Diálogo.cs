using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Diálogo : MonoBehaviour
{
    [SerializeField]
    TMP_Text codeText;
    string codeTextValue = "";

    private void Update()
    {
        codeText.text = codeTextValue;

        if (codeTextValue == "Eros,Vasilios,Ireneo,Learco,")
        {
            CodeInteractSalon.IsDoorOpened = true;
        }
        if (codeTextValue.Length >= 28)
            codeTextValue = "";

    }

    public void Addstring(string digit)
    {
        codeTextValue += digit;
    }

}