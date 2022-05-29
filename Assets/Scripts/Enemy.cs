using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 Direction;
    public float Speed;
    public int Points;
    public int Health;

    public void initEnemy(int points, int health, Vector3 direction, int speed)
    {
        Points = points;
        Health = health;
        Direction = direction;
        Speed = speed;
    }

    private void Update()
    {
        transform.position += Direction * Speed * Time.deltaTime;
        if (Health <= 0)
        {
            GameManager.Instance.Score += Points;
            GameManager.Instance.Energy += Points;
            Destroy(gameObject);
        }
        else if (!BoundingBox.Instance.IsItBound(transform.position))
        {
            Destroy(gameObject);
        }
    }
}
