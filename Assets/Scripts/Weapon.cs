using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletprefab;
    public Transform firepoint;
    public float fireForce = 20f;
    public Camera cam;
    Vector2 mouse_position;
    Vector2 aim_direction;
    float fire_timer;
    public float fire_CD;
    public GameObject player;
    public float shoot_anim_time = 0.3f;
    float shoot_anim_timer;
    Animator animator;
    public bool auto_fire = true;
    sound sfx_manager;
    public AudioClip shoot_sound;
    private void Start()
    {
        sfx_manager = GameObject.FindGameObjectWithTag("manager").GetComponent<sound>();
        animator = player.GetComponent<Player_movement>().animator;
    }
    void FixedUpdate()
    {
        //making weapon look at mouse

        mouse_position = cam.ScreenToWorldPoint(Input.mousePosition);
        aim_direction = new Vector2(
        mouse_position.x - transform.position.x, mouse_position.y - transform.position.y);

        transform.up = aim_direction;

        //firing

        fire_timer += Time.deltaTime;
        if ((Input.GetMouseButtonDown(0) || auto_fire) && fire_timer >= fire_CD)
        {
            Fire();
            fire_timer = 0;
        }

        //animate
        if (animator.GetBool("shooting") == true)
        {
            shoot_anim_timer += Time.deltaTime;
            if (shoot_anim_timer >= shoot_anim_time)
            {
                animator.SetBool("shooting", false);
                shoot_anim_timer = 0;
            }
        }
    }
    public void Fire()
    {
        sfx_manager.play_sound(shoot_sound);
        animator.SetBool("shooting", true);
        GameObject bullet = Instantiate(bulletprefab, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firepoint.up * fireForce, ForceMode2D.Impulse);
    }
}
