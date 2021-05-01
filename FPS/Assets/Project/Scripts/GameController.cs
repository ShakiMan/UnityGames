using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text lifes;
    public Text enemies;
    public Text win;
    public PlayerCotroller Player;
    public GameObject Enemies;

    // Start is called before the first frame update
    void Start()
    {
        win.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        lifes.text = "Lifes: " + Player.Lifes;
        int aliveEnemies = Enemies.GetComponentsInChildren<EnemyController>().Length;
        enemies.text = "Enemies left: " + aliveEnemies;
        if (aliveEnemies == 0)
        {
            win.gameObject.SetActive(true);
        }
    }
}