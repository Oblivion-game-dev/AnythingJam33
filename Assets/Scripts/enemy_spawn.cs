using System.Collections;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
    public float spawn_time;
    public int wave;
    public int enemy_count;
    public GameObject enemy;
    public float time_decrease_each_wave = 0.1f;
    public float time_between_waves = 1;
    public GameObject[] spawners;
    bool wave_done = true;

    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("spawner");
    }
    void Update()
    {
        if (wave_done)
        {
            StartCoroutine(Spawn());
        }
    }

    IEnumerator Spawn()
    {
        wave_done = false;
        for (int i = 0; i < enemy_count; i++)
        {
            GameObject enemy_clone = Instantiate(enemy);
            enemy_clone.transform.position
                = spawners[Random.Range(0, spawners.Length)].gameObject.transform.position
                 + new Vector3 (Random.Range(-5,5),Random.Range(-5,5)); //random spawn position

            yield return new WaitForSeconds(spawn_time);
        }
        if(spawn_time - time_decrease_each_wave > 0) spawn_time -= time_decrease_each_wave;
        
        yield return new WaitForSeconds(time_between_waves);
        wave += 1;
        wave_done = true;
    }
}
