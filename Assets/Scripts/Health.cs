using System.Collections;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public GameObject s3;
    public GameObject s2;


    public int health = 3;
    public bool immunity = false;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy" && immunity == false)
        {
            health -= 1;
            if (health == 0)
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
    }
    public void Trigger()
    {
        StartCoroutine(immunityy());
    }

    private IEnumerator immunityy()
    {
        immunity = true;
        yield return new WaitForSeconds(5f);
        immunity = false;
    }
}
