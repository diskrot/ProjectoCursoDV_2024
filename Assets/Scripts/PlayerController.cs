using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionReference movementInput;
    public Vector2 movement2d;
    private Rigidbody2D rigidbody2d;
    public Animator animator;
    public float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = this.gameObject.GetComponent<Rigidbody2D>();
        movement2d = new Vector2();
    }

    // Update is called once per frame
    void Update()
    {
        movement2d = movementInput.action.ReadValue<Vector2>();
        animator.SetFloat("xspeed",movement2d.x);
        animator.SetFloat("yspeed",movement2d.y);
    }
    void FixedUpdate()
    {
        rigidbody2d.AddForce(movement2d * speed);
    }
}
