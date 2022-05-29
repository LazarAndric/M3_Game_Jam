using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMeniUi : MonoBehaviour
{
    public GameObject Panel;
    public GameObject OverScreen;
    public Image selctor0;
    public Image selctor1;

    public List<GameObject> playerPositions = new List<GameObject>();
    public static MainMeniUi Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    public void startGameover()
    {
        GameManager.Instance.isInit = false;
        OverScreen.SetActive(true);
        Panel.SetActive(true);
    }

    public int index0 = 0;
    public int index1 = 2;

    public void Play()
    {
        GameManager.Instance.initPlayers(5, 3, index0, index1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
            index0++;
            if (index0 > 2)
            {
                index0 = 0;
            }
            if (index0 == index1)
            {
                index0++;
                if (index0 > 2)
                {
                    index0 = 0;
                }
            }
            selctor0.transform.position = playerPositions[index0].transform.position;

        }
        if (Input.GetKeyDown(KeyCode.Joystick2Button3))
        {
            index1++;
            
            if (index1 > 2)
            {
                index1 = 0;
            }
            if (index0 == index1)
            {
                index1++;
                if (index1 > 2)
                {
                    index1 = 0;
                }
            }
            selctor1.transform.position = playerPositions[index1].transform.position;

        }

    }
}
