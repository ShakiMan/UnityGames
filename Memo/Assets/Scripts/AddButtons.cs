using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    [SerializeField] private Transform cardField;
    [SerializeField] private GameObject btn;

    [SerializeField] private int width;
    [SerializeField] private int height;
    
    void Awake()
    {
        width = MenuScript.Width;
        height = MenuScript.Height;
        for (int i = 0; i < width * height; i++)
        {
            GameObject button = Instantiate(btn, cardField, false);
            button.name = "" + i;
        }
    }
}
