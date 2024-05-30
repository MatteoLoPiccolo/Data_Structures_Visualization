using TMPro;
using UnityEngine;

public class InputHandlerSizeOfArray : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Array arrayScript;

    public void OnSizeEndEdit(string input)
    {
        if (int.TryParse(input, out int size))
        {
            Debug.Log("Numero valido: " + size);
            arrayScript.CreateArray(size);
        }
        else
        {
            Debug.LogError("Input non valido. Inserisci un numero intero.");
        }
    }
}