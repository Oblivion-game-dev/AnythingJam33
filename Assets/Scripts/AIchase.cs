using UnityEngine;

public class AIchase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distance_before_stop = 1;
    private float distance;
    float angle;
    bool facing_right = false;
    public float enemy_sight = 100;
    enemy_detector enemy_Detector;
    Vector2 direction;
    public GameObject sprite;
    void Start()
    {
        player = GameObject.Find("Player");
        enemy_Detector = GetComponentInChildren<enemy_detector>();
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        direction = player.transform.position - transform.position;
        direction.Normalize();
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        sprite.transform.rotation  = Quaternion.Euler(0,0,-transform.rotation.z);

        if (distance <= enemy_sight && distance >= distance_before_stop && !enemy_Detector.near_another)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }

        //flipping
        if (angle <= 90 && angle >= -90 && !facing_right)
        {
            Flip();
        }
        else if((angle > 90 || angle < -90) && facing_right)
        {
            Flip();
        }
    }

    void Flip()
    {
        facing_right = !facing_right;
        Vector3 scale = sprite.transform.localScale;
        scale.x *= -1;
        sprite.transform.localScale = scale;
    }
}
