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
    public GameObject[] enemies;
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

            if (wave < 2)
            {
                Spawn(1, 2f);
            }
            else if (wave < 4)
            {
                Spawn(1, 1.5f);
            }
            else if (wave < 9)
            {
                Spawn(2, 1f);
            }
            else if (wave < 13)
            {
                Spawn(2, 0.8f);
            }
            else if (wave < 16)
            {
                Spawn(3, 0.8f);
            }
            else if (wave < 19)
            {
                Spawn(3, 0.6f);
            }
            else if (wave >= 19)
            {
                Spawn(3, 0.4f);
            }


            yield return new WaitForSeconds(spawn_time);
        }

        yield return new WaitForSeconds(time_between_waves);
        wave += 1;
        wave_done = true;
    }
    void Spawn(int types, float time)
    {
        GameObject enemy_clone = Instantiate(enemies[Random.Range(0, types)]);;
        enemy_clone.transform.position
            = spawners[Random.Range(0, spawners.Length)].gameObject.transform.position
                + new Vector3(Random.Range(-5, 5), Random.Range(-5, 5));
        spawn_time = time;
    }
}
