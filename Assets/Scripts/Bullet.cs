using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string DissapearTag;
    public string EnemyTag;
    public int Damage;
    public int Speed;
    public Vector3 Direction;
    public CircleCollider2D Collider;
    public BulletType BulletType;
    public Effect Effect;
    public void initBullet(BulletType type, float colliderRadius, int aoeDamage,int speed, Vector2 direction, string enemyTag, string dissapearTag, int damage)
    {
        Effect.Damage = aoeDamage;
        BulletType = type;
        Speed = speed;
        Direction = direction;
        Damage = damage;
        EnemyTag = enemyTag;
        DissapearTag = dissapearTag;
        Collider.radius = colliderRadius;
    }
    private void Update()
    {
        transform.position += Speed* Direction * Time.deltaTime;
        if (!BoundingBox.Instance.IsItBound(transform.position))
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(EnemyTag))
        {
            var enemy = collision.GetComponent<Enemy>();
            enemy.Health -= Damage;

            if(BulletType== BulletType.AOE)
            {
                Effect.gameObject.SetActive(true);
            }
            if(BulletType != BulletType.DEATH_BULLET)
                Destroy(gameObject);
        }
    }
}
public enum BulletType
{
    Classic,
    AOE,
    DEATH_BULLET
}
