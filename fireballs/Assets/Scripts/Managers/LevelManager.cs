using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    Text soulText;

    [SerializeField]
    GameObject inGamePanel;

    [SerializeField]
    GameObject levelDonePanel;

    [SerializeField]
    GameObject gameOverPanel;


    public int brokenCube = 0;
    public bool isLevelDone;
    public bool isGameOver;

    Player player;
    CubeTower cubeTower;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        cubeTower = FindObjectOfType<CubeTower>();
    }

    private void Update()
    {
        soulText.text = "Soul: " + player._soul.ToString();
        if (player._soul <= 0)
            isGameOver = true;
        if (brokenCube == cubeTower._cubeSize)
            isLevelDone = true;

        if (isGameOver)
        {
            gameOverPanel.SetActive(true);
            inGamePanel.SetActive(false);
            levelDonePanel.SetActive(false);
            Time.timeScale = 0;
        }
        else if (isLevelDone)
        {
            gameOverPanel.SetActive(false);
            inGamePanel.SetActive(false);
            levelDonePanel.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            gameOverPanel.SetActive(false);
            inGamePanel.SetActive(true);
            levelDonePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }


}
