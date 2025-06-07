using UnityEngine;

public class exp_system : MonoBehaviour
{
    public int exp = 0;
    public int level = 0;
    public int exp_required = 10;
    public int exp_increase_each_level;
    void Update()
    {
        if (exp >= exp_required)
        {
            exp = 0;
            level += 1;
            exp_required *= exp_increase_each_level;
        }
    }
}
