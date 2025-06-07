using System.Collections;
using UnityEngine;

public class enemy_spawn : MonoBehaviour
{
    public float spawn_time;
    public int wave;
    public int enemy_count;
    public GameObject enemy;
    bool wave_done = true;
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
            enemy_clone.transform.position = gameObject.transform.position;

            yield return new WaitForSeconds(spawn_time);
        }
        spawn_time -= 0.1f;

        yield return new WaitForSeconds(enemy_count * spawn_time);
        wave_done = true;
    }
}
