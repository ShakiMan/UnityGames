using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    [SerializeField] public int levelIndex;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("out");
        if (other.CompareTag("Player"))
        {
            print("in");
            GameController.LoadScene(levelIndex);
        }
    }
}
