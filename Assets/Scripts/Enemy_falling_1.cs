using UnityEngine;

public class Enemy_falling_1 : MonoBehaviour
{
    public Vector3 Direction;
    public float Speed;
    public int Health;
    public int Points;

    public void initEnemy_falling_1(int health, int points, Vector3 direction, int speed)
    {
        Health = health;
        Points = points;
        Direction = direction;
        Speed = speed;
        //On init
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
