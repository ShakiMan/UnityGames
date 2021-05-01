using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public static int Width { get; private set; }
    public static int Height { get; private set; }

    public void Start2X2()
    {
        StartGame(2, 2);
    }
    
    public void Start2X4()
    {
        StartGame(2, 4);
    }
    
    public void Start4X4()
    {
        StartGame(4, 4);
    }

    private void StartGame(int xCards, int yCards)
    {
        Width = xCards;
        Height = yCards;
        SceneManager.LoadScene("Game");
    }
    
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            Start2X2();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            Start2X4();
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            Start4X4();
        }
    }
}
