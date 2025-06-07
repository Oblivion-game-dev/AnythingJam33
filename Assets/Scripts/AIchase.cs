using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;

public class AIchase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distance_before_stop = 1;
    private float distance;
    public float enemy_sight = 100;
    enemy_detector enemy_Detector;

    void Start()
    {
        player = GameObject.Find("Player");
        enemy_Detector = GetComponentInChildren<enemy_detector>();
    }
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        if (distance <= enemy_sight && distance >= distance_before_stop && !enemy_Detector.near_another)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
