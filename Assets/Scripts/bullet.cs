using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float damage = 5;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().health -= damage;
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("surroundings"))
        {
            Destroy(gameObject);
        }
    }
}
