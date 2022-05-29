using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public int Damage;
    private void OnCollisionStay(Collision collision)
    {
        for(int i=0;i< collision.contactCount; i++)
        {
            collision.contacts[0].otherCollider.GetComponent<Enemy>().Health -= Damage;
        }
        Destroy(gameObject);
    }
}
