using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiHandler : MonoBehaviour
{
    public static UiHandler Instance;
    public Slider energyBar;
    public Text score;
    public GameObject lifeBar;
    public GameObject life;
    public GameObject shield;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void AddLife(int numberOf)
    {
        for (int i = 0; i < numberOf; i++)
        {
            var createImage = Instantiate(life) as GameObject;
            createImage.transform.SetParent(lifeBar.transform, false);
        }
    }

    public void AddShield(int numberOf)
    {
        for (int i=0;i< numberOf; i++) {
            var createImage = Instantiate(shield) as GameObject;
            createImage.transform.SetParent(lifeBar.transform, false);
        }
    }

    public void RemuveLife()
    {
        if (lifeBar.transform.childCount > 0)
        {
            Destroy(lifeBar.transform.GetChild(lifeBar.transform.childCount - 1).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        energyBar.value = GameManager.Instance.Energy;
        score.text = GameManager.Instance.Score.ToString();

    }
}
