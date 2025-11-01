using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static GameObject player;

    private void Awake()
    {
        if(player == null)
        {
            player = this.gameObject;
        }
        else
        {
            Destroy(this);
        }
    }


    [Header("Movement")]
    public float speed;
    public float ground_drag;
    private float adjusted_speed;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;
    public float gravityMultiplier;

    Vector3 direction;
    Rigidbody rb;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ground;
    bool grounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight*0.5f + 0.2f, ground);

        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if(flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            adjusted_speed = speed * 4;
        }
        else
        {
            adjusted_speed = speed;
        }

        if(grounded)
        {
            rb.drag = ground_drag;
        }
        else
        {
            rb.drag = 0;
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y - 0.01f, rb.velocity.z);
        }
    }

    private void FixedUpdate()
    {
        direction = orientation.forward * verticalInput + orientation.right * horizontalInput;
        if(grounded)
        {
            rb.AddForce(direction.normalized * adjusted_speed * 10f, ForceMode.Force);
        }
        else
        {
            rb.AddForce(direction.normalized * adjusted_speed * 10f * gravityMultiplier, ForceMode.Force);
        }
    }
}
