using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string exp_type;
    public GameObject[] exp_types;
    GameObject exp;
    public float health;
    public float max_health;
    public AudioClip kill_sound;
    public sound sfx_manager;
    void Start()
    {
        sfx_manager = GameObject.FindGameObjectWithTag("manager").GetComponent<sound>();
        decide_exp_type();
    }
    void Update()
    {
        if (health <= 0)
        {
            death();
        }
    }

    void death()
    {
        sfx_manager.play_sound(kill_sound);
        GameObject exp_drop = Instantiate(exp);
        exp_drop.gameObject.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }

    void decide_exp_type()
    {
        switch (exp_type)
        {
            case "small":
                exp = exp_types[0];
                break;
            case "normal":
                exp = exp_types[1];
                break;
            case "big":
                exp = exp_types[2];
                break;
            default:
                return;

        }
    }
}
