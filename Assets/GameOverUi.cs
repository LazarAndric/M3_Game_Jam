using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUi : MonoBehaviour
{
    public Text score;
  
    void Update()
    {
        score.text = GameManager.Instance.Score.ToString();
    }

    public void PlayAgain()
    {

    }
    public void MainMeni()
    {

    }


}
