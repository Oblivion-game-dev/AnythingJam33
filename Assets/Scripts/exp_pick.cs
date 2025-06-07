using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exp_pick : MonoBehaviour
{
    public int exp_point;
    Vector2 exp_velocity = Vector2.zero;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "exp_picker")
        {
            transform.position
            = Vector2.SmoothDamp(transform.position, other.transform.position, ref exp_velocity, 0.25f);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            other.gameObject.GetComponent<exp_system>().exp += exp_point;
            Destroy(gameObject);
        }
    }
}
