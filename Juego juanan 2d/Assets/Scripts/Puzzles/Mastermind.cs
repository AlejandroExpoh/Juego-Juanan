using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mastermind : MonoBehaviour
{
    public Button[] colorButtons; // Referencia a los botones peque�os
    public Image[] borders; // Referencia a los bordes grandes
    public Button checkButton; // Bot�n de comprobar

    private string[] colors = { "R", "G", "B", "C", "M", "Y" }; // Colores disponibles
    private string[] correctCombination = new string[4]; // Contrase�a aleatoria
    private string[] playerCombination = new string[4]; // Combinaci�n del jugador

    private void Start()
    {
        // Generar la combinaci�n correcta
        for (int i = 0; i < correctCombination.Length; i++)
        {
            correctCombination[i] = colors[Random.Range(0, colors.Length)];
        }
        Debug.Log("Combinaci�n correcta: " + string.Join(", ", correctCombination));

        // Inicializar la combinaci�n del jugador en gris (sin seleccionar)
        for (int i = 0; i < playerCombination.Length; i++)
        {
            playerCombination[i] = "None";
        }

        // Asignar eventos a los botones peque�os
        for (int i = 0; i < colorButtons.Length; i++)
        {
            int index = i; // Capturar �ndice local para la lambda
            colorButtons[i].onClick.AddListener(() => ChangeColor(index));
        }

        // Asignar evento al bot�n de comprobar
        checkButton.onClick.AddListener(CheckCombination);
    }

    private void ChangeColor(int index)
    {
        // Cambiar el color del bot�n peque�o al siguiente en la lista
        int currentIndex = System.Array.IndexOf(colors, playerCombination[index]);
        currentIndex = (currentIndex + 1) % colors.Length;
        playerCombination[index] = colors[currentIndex];

        // Cambiar el color visual del bot�n
        Color newColor = GetColorFromCode(playerCombination[index]);
        colorButtons[index].GetComponent<Image>().color = newColor;
    }

    private void CheckCombination()
    {
        // Revisar la combinaci�n del jugador y actualizar los bordes
        for (int i = 0; i < correctCombination.Length; i++)
        {
            if (playerCombination[i] == correctCombination[i])
            {
                borders[i].color = Color.green; // Verde si el color y la posici�n son correctos
            }
            else if (System.Array.Exists(correctCombination, c => c == playerCombination[i]))
            {
                borders[i].color = Color.yellow; // Amarillo si el color est� pero en otra posici�n
            }
            else
            {
                borders[i].color = Color.red; // Rojo si el color no est�
            }
        }

        // Comprobar si el jugador acert� la combinaci�n completa
        if (string.Join("", playerCombination) == string.Join("", correctCombination))
        {
            Debug.Log("�Has acertado la combinaci�n!"); 
            CodeInteract.IsDoorOpened = true;
        }
        
    }

    private Color GetColorFromCode(string code)
    {
        switch (code)
        {
            case "R": return Color.red;
            case "G": return Color.green;
            case "B": return Color.blue;
            case "C": return Color.cyan;
            case "M": return new Color(1f, 0f, 1f); // Magenta
            case "Y": return Color.yellow;
            default: return Color.gray; // Color por defecto
        }
    }
}
