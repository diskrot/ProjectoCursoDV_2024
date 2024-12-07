using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    public GameObject target;
    public float speed = 1.0f;
    public float detectionRange = 5.0f;
    
    // Start is called before the first frame update
    void Start(){}

    // Update is called once per frame
    void Update(){}

    void Awake()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (IsTargetNearby(target))
        {
            MoveTowardsTarget(target);
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
    }

    bool IsTargetNearby(GameObject target)
    {
        return  target != null && 
                Vector3.Distance(target.transform.position, this.transform.position) < detectionRange;
    }

    void MoveTowardsTarget(GameObject target)
    {
        Vector3 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
        rigidBody.velocity = direction.normalized * speed;
    }
}
