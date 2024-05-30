using System;
using TMPro;
using UnityEngine;

public class Array : MonoBehaviour
{
    [Header("Gameobjects references")]
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] GameObject container;

    [Header("UI references")]
    [SerializeField] TextMeshProUGUI indexText;
    [SerializeField] TextMeshProUGUI elementText;

    SpriteRenderer[] array;
    private readonly float elementWidth = 0.8f;

    public void CreateArray(int size)
    {
        if (array != null)
        {
            foreach (var obj in array)
            {
                Destroy(obj.gameObject);
            }
        }

        float startX = CalculateStartingArrayPosition(size);

        array = new SpriteRenderer[size];

        for (int i = 0; i < size; i++)
        {
            float xPos = startX + i * elementWidth;
            array[i] = Instantiate(sprite, new Vector3(xPos, 0, 0), Quaternion.identity);
            array[i].gameObject.transform.SetParent(container.transform, false);

            TextMeshProUGUI textMeshProUI = array[i].GetComponentsInChildren<TextMeshProUGUI>()[0];
            if (textMeshProUI != null)
            {
                textMeshProUI.text = "[ " + i + " ]";
            }
        }
    }

    private float CalculateStartingArrayPosition(int size)
    {
        float totalWidth = size * elementWidth;
        float startX = (-totalWidth / 2) + (elementWidth / 2);
        return startX;
    }

    public void SetElementsOfArray(string[] elements)
    {
        if (array == null)
        {
            Debug.LogError("Array non ancora creato. Crea prima l'array con la dimensione desiderata.");
            return;
        }

        if (elements.Length > array.Length)
        {
            Debug.LogError("Il numero di elementi non corrisponde alla dimensione dell'array.");
            return;
        }

        for (int i = 0; i < elements.Length; i++)
        {
            SetElementText(i, elements[i]);
        }
    }

    private void SetElementText(int index, string text)
    {
        TextMeshProUGUI textMeshProUI = array[index].GetComponentsInChildren<TextMeshProUGUI>()[1];
        if (textMeshProUI != null)
        {
            textMeshProUI.text = text;
        }
        else
        {
            Debug.LogError("Componente TextMeshProUI non trovato come figlio di array[" + index + "]. Assicurati che sia configurato correttamente.");
        }
    }
}