using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUi : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Over;
    public Text score;
    public static GameOverUi Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    void Update()
    {
        score.text = GameManager.Instance.Score.ToString();
    }

    public void GameOver()
    {
        Panel.SetActive(false);
        Over.SetActive(true);
    }
    public void PlayAgain()
    {
        GameManager.Instance.initPlayers(5, 3, MainMeniUi.Instance.index0, MainMeniUi.Instance.index1);
    }
    public void MainMeni()
    {

    }


}
