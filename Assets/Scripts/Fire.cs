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

    public void FireOn(BulletType type, float aoeRadius, int aoeDamage,  Bullet obj, Vector3 position, Vector2 direction, int speed)
    {
        var b = Instantiate(obj);
        b.transform.position = position;
        b.initBullet(type, aoeRadius, aoeDamage, speed, direction, EnemyTag, DissapearingTag, 10);
    }
}