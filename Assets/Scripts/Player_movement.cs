
using UnityEngine;
// basic movement (u can update it later)
public class Player_movement : MonoBehaviour
{
    public float MoveSpeed = 5f; // player movement speed
    public Rigidbody2D rb; // get the rigidbody of the player
    Vector2 movement; // movement input var
    public Weapon weapon;
    Vector2 mouseposition;
    public Camera cam;
 
    void Update()
    {
        // Input :

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetMouseButtonDown(0))
        {
            weapon.Fire();
        }
       mouseposition = cam.ScreenToWorldPoint(Input.mousePosition);

    }
    
    private void FixedUpdate()
    {
        // applying movement to the rigidbody2D :
        movement.Normalize(); // normalizing movement so it doesn't go faster diagonally
            rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime); 
        Vector2 aimDirection = mouseposition - rb.position;
        float aimangle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = aimangle;
    }


}
