using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBox : MonoBehaviour
{
    public static BoundingBox Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public GameObject TopRight;
    public GameObject DownLeft;

    public bool IsItBound(Vector3 position)
    {
        if (position.x > DownLeft.transform.position.x && position.y > DownLeft.transform.position.y && position.x < TopRight.transform.position.x && position.y < TopRight.transform.position.y)
        {
            return true;
        }

        return false;
    }


}
