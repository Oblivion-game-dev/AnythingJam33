using UnityEngine;

public class enemy_detector : MonoBehaviour
{
    //this script prevent enemy from pushing each other
    public bool near_another;
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            near_another = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            near_another = false;
        }
    }
}
