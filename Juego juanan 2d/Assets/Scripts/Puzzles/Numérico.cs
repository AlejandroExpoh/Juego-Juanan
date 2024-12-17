using Pathfinding.Ionic.Zip;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Numérico : MonoBehaviour
{
    [SerializeField]
    TMP_Text codeText;
    string codeTextValue = "";

    private void Update()
    {
        codeText.text = codeTextValue;

        if (codeTextValue == "1751")
        {
            CodeInteract.IsDoorOpened = true;
        }
        if (codeTextValue.Length >= 4)
            codeTextValue = "";
     
    }

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }

}
