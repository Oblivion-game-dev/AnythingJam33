using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bullet_duration = 1.5f;
    float timer;
    public float damage = 5;
    void Start()
    {
        
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= bullet_duration)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().health -= damage;
            Destroy(gameObject);
        }
    }
}
