using System.Collections;
using UnityEngine;

public class enemy_detector : MonoBehaviour
{
    public float attack_rate;
    bool is_attacking = false;
    public bool near_another;
    public Animator animator;
    float attack_anim_timer;
    public float attack_anim_time = 0.2f;
    sound sfx_manager;
    public AudioClip damage_sound;

    void Start()
    {
        sfx_manager = GameObject.FindGameObjectWithTag("manager").GetComponent<sound>();
    }
    void Update()
    {
        if (animator.GetBool("attacking") == true)
        {
            attack_anim_timer += Time.deltaTime;
            if (attack_anim_timer >= attack_anim_time)
            {
                animator.SetBool("attacking", false);
                attack_anim_timer = 0;
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            near_another = true;
        }
        if (other.gameObject.tag == "player" && !is_attacking)
        {
            StartCoroutine(damaging(other.gameObject));
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            near_another = false;
        }
    }
    IEnumerator damaging(GameObject hit)
    {
        if (!hit.GetComponent<Health>().immunity)
        {
            hit.GetComponent<Health>().health -= 1;
        }
        is_attacking = true;
        animator.SetBool("attacking",true);
        sfx_manager.play_sound(damage_sound);
        yield return new WaitForSeconds(attack_rate);
        is_attacking = false;
    }
    
}
