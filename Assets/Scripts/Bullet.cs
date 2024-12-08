using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 5.0f;
    public int damage = 1;
    public GameObject shooter;
    public List<string> ignoreTags;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision with " + collision.gameObject.name);

        if(!(ignoreTags.Contains(collision.gameObject.tag)))
        {
            if (collision.gameObject.GetComponent<HealthSystem>() != null)
            {
                //Debug.Log("Hit");
                collision.gameObject.GetComponent<HealthSystem>().harm += damage;
            }
            if (collision.gameObject != shooter)
            {
                Destroy(this.gameObject);
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Trigger");
        if(!(ignoreTags.Contains(collision.gameObject.tag)))
        {
            if (collision.gameObject.GetComponent<HealthSystem>() != null)
            {
                //Debug.Log("Hit");
                collision.gameObject.GetComponent<HealthSystem>().harm += damage;
            }
            if (collision.gameObject != shooter)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
