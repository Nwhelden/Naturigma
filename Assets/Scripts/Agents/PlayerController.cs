    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movSpeed = 5.0f;
    public float rotSpeed = 0.15f;
    public float jumpPower = 2.0f;
    public AudioClip moveSFX;
    public AudioClip jumpSFX;
    public AudioClip deathSFX;

    private bool canJump = false;
    private bool disabled = false;
    private Vector3 jumpDir;
    private Animator animator;
    private Rigidbody rb;
    private AudioSource aSource;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        aSource = GetComponent<AudioSource>();
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
            HandleAudio(hMovement, vMovement);
            HandleMovement(hMovement, vMovement);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Hazard>() && deathSFX)
        {
            aSource.PlayOneShot(deathSFX);
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
        LayerMask groundLayer = LayerMask.GetMask("Ground");
        if (Physics.CheckSphere(transform.position, GetComponent<CapsuleCollider>().radius, groundLayer))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(jumpDir * jumpPower, ForceMode.Impulse);
            canJump = false;
        }
    }

    private void HandleAudio(float hMovement, float vMovement)
    {
        if ((hMovement != 0 || vMovement != 0) && moveSFX != null)
        {
            aSource.PlayOneShot(moveSFX);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canJump && jumpSFX != null)
        {
            aSource.time = 0.75f;
            aSource.PlayOneShot(jumpSFX);
            aSource.time = 0.0f;
        }
    }

    public void ToggleActive()
    {
        disabled = !disabled;
    }

    public void Disable()
    {
        disabled = true;
    }

    public bool isActive()
    {
        return !disabled;
    }

    //for some reason this causes the character to roll?
    /*
     Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
     rb.velocity = moveInput * movSpeed;
    */

}
