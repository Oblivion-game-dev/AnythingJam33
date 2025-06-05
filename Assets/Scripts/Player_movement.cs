
using UnityEngine;
// basic movement (u can update it later)
public class Player_movement : MonoBehaviour
{
    public float MoveSpeed = 5f; // player movement speed
    public Rigidbody2D rb; // get the rigidbody of the player
    Vector2 movement; // movement input var

 
    void Update()
    {
        // Input :

            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
    }
    
    private void FixedUpdate()
    {

        // applying movement to the rigidbody2D :
            movement.Normalize(); // normalizing movement so it doesn't go faster diagonally
            rb.MovePosition(rb.position + movement * MoveSpeed * Time.fixedDeltaTime); 
    }
}
