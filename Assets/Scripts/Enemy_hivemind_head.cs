using UnityEngine;

public class Enemy_hivemind_head : MonoBehaviour
{
    public Vector3 Direction;
    public float Speed;

    public void initEnemy_hivemind_head(Vector3 direction, int speed)
    {
        Direction = direction;
        Speed = speed;
        //On init
    }
    public int Health;

    private void Update()
    {
        transform.position += Direction * Speed * Time.deltaTime;
        if (Health <= 0 || !BoundingBox.Instance.IsItBound(transform.position))
        {
            Destroy(gameObject);
        }
    }
}
