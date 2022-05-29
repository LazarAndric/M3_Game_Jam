using UnityEngine;

public class Enemy_hivemind_body : MonoBehaviour
{
    public Vector3 Direction;
    public float Speed;

    public void initEnemy_hivemind_body(Vector3 direction, int speed)
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
