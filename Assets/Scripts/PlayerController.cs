using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movSpeed = 5.0f;
    public float rotSpeed = 0.15f;
    public float jumpPower = 2.0f;

    private bool canJump = false;
    private bool disabled = false;
    private Vector3 jumpDir;
    private Animator animator;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        jumpDir = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        float hMovement = 0;
        float vMovement = 0;
        float jMovement = 0;

        if (!disabled)
        {
            hMovement = Input.GetAxisRaw("Horizontal");
            vMovement = Input.GetAxisRaw("Vertical");

            HandleAnimations(hMovement, vMovement);
            HandleMovement(hMovement, vMovement);
            //HandleAudio(hMovement, vMovement);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }

    private void HandleAnimations(float hMovement, float vMovement)
    {
        if (hMovement != 0 || vMovement != 0)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            animator.SetTrigger("Jump");
        }
    }

    private void HandleMovement(float hMovement, float vMovement)
    {
        // Movement
        Vector3 inputVector = new Vector3(hMovement, 0.0f, vMovement);
        transform.Translate(inputVector * Time.deltaTime * movSpeed, Space.World);

        // Rotation faces movement direction
        if (hMovement != 0 || vMovement != 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(inputVector), rotSpeed);
        }

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(jumpDir * jumpPower, ForceMode.Impulse);
            canJump = false;
        }
    }

    private void HandleAudio()
    {

    }

    public void ToggleActive()
    {
        disabled = !disabled;
    }

    //for some reason this causes the character to roll?
    /*
     Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
     rb.velocity = moveInput * movSpeed;
    */

}
