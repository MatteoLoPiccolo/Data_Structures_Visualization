using TMPro;
using UnityEngine;

public class InputHandlerElementsOfArray : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Array arrayScript;

    public void OnElementsEndEdit(string input)
    {
        string[] elements = input.Split(',');
        arrayScript.SetElementsOfArray(elements);
    }
}