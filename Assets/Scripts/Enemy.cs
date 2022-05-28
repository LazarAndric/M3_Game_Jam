using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 Direction;
    public float Speed;

    public void initEnemy(Vector3 direction, int speed)
    {
        Direction = direction;
        Speed = speed;
        //On init
    }
    public int Health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Die"))
            Destroy(gameObject);
    }
    private void Update()
    {
        transform.position += Direction * Speed * Time.deltaTime;
        if (Health <= 0 || !BoundingBox.Instance.IsItBound(transform.position))
        {
            Destroy(gameObject);
        }
    }
}
