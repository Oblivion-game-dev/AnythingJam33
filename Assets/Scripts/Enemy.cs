using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 10;
    public float max_health = 10;
    void Update()
    {
        if (health <= 0)
        {
            death();
        }
    }

    void death()
    {
        Destroy(gameObject);
    }
}
