
using UnityEngine;
// basic movement (u can update it later)
public class Player_movement : MonoBehaviour
{
    public float MoveSpeed = 5f; // player movement speed
    public Rigidbody2D rb; // get the rigidbody of the player
    Vector2 movement; // movement input var
    public Weapon weapon;
    public Animator animator;
    bool facing_right = false;
    public AudioSource idk;
    public GameObject sprite;
    private void Start()
    {
        idk.Play();
    }
    void Update()
    {
        // Input :

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x > 0 && !facing_right)
            Flip();
        else if (movement.x < 0 && facing_right)
            Flip();

    }
    private void FixedUpdate()
    {
        // applying movement to the rigidbody2D :
        movement.Normalize();
        rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime);

        // animate
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("running", true);
        }
        else
        {
            animator.SetBool("running", false);
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
