using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public static Fire Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public GameObject bullet;

    public void FireOn()
    {
        var up = gameObject.transform.up * Time.deltaTime * 0.1f;
        
        Instantiate(bullet, transform);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            FireOn();
        }
    }

}
