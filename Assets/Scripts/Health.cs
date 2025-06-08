using System.Collections;
using System.Resources;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject s3;
    public GameObject s2;
    public float attack_rate;
    public float immunity_time = 3f;
    public int health = 3;
    public bool immunity = false;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (health <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
        if (health == 2)
        {
            s3.SetActive(false);
        }
        if (health == 1)
        {
            s2.SetActive(false);
        }
    }
    //damaging moved to enemy_detector.cs
    public void Trigger()
    {
        StartCoroutine(immunityy());
    }

    private IEnumerator immunityy()
    {
        immunity = true;
        yield return new WaitForSeconds(immunity_time);
        immunity = false;
    }
}
