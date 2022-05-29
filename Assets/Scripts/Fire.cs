using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public static Fire Instance;
    public string EnemyTag;
    public string DissapearingTag;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void FireOn(Bullet obj, Transform parent, Vector2 direction, int speed)
    {
        var b = Instantiate(obj);
        b.transform.position = parent.position;
        b.initBullet(speed, direction, EnemyTag, DissapearingTag, 10);
    }
}