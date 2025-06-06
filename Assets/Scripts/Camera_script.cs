using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_script : MonoBehaviour
{
    
    public float sight; //camera sight (default: 10)
    public float camera_delay; //camera follow delay time
    Vector3 offset; //camera's position offset
    Vector3 velocity = Vector3.zero; //camera movement velocity
    public Transform target; //camera target
    private void Update()
    {
        //adjust variables

        offset = new Vector3(0, 0, -sight);

        Vector3 target_position = target.transform.position + offset;

        //applying camera movement

        gameObject.transform.position = Vector3.SmoothDamp(
            transform.position, target_position, ref velocity, camera_delay
            );
    }


}
