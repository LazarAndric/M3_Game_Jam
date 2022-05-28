using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiHandler : MonoBehaviour
{
    public Slider energyBar;
    public Text score;
    public GameObject lifeBar;
    public GameObject life;

    public void AddLife()
    {
        var createImage = Instantiate(life) as GameObject;
        createImage.transform.SetParent(lifeBar.transform, false);
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
        score.text = "score123";

        if (Input.GetKeyDown(KeyCode.N))
        {
            AddLife();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            RemuveLife();
        }

    }
}
