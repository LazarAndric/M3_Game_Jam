using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string DissapearTag;
    public string EnemyTag;
    public int Damage;
    public int Speed;
    public Vector3 Direction;
    public void initBullet(int speed, Vector2 direction, string enemyTag, string dissapearTag, int damage)
    {
        Speed = speed;
        Direction = direction;
        Damage = damage;
        EnemyTag = enemyTag;
        DissapearTag = dissapearTag;
    }
    private void Update()
    {
        transform.position += Speed* Direction * Time.deltaTime;
        if (!BoundingBox.Instance.IsItBound(transform.position))
        {
            Destroy(gameObject);
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.CompareTag(EnemyTag))
    //    {
    //        collision.GetComponent<Enemy>().Health -= Damage;
    //        Destroy(gameObject);
    //    }
    //    else if (collision.CompareTag(DissapearTag))
    //    {
    //        Destroy(gameObject);
    //    }

    //}
}
