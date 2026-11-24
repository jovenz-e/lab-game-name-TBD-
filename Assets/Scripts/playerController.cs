using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f;
    public float jumpHeight = 1.5f;
    public float gravity = -19.62f;
    public GameObject projectilePrefab;
    private CharacterController controller;
    private Rigidbody rigid;
    private Vector3 velocity;
    private bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
      controller = GetComponent<CharacterController>();
      rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      // 1. Check if grounded and reset downward velocity
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // 2. Get WASD / Arrow Key input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Move relative to the direction the player is facing
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // 3. Handle Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

         // 4. Apply Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //projectiles
        if(Input.GetKeyDown(KeyCode.E))
        {
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
  }
}
