using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int health = 100;
    public int harm = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health -= harm;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
        harm = 0;
    }
}
