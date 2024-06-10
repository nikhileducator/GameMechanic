using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public int coinsCollected = 0;

    public float jumpForce = 5f;  // Adjustable jump force
    private Rigidbody rb;  // Reference to the Rigidbody component
    private bool isGrounded;  // To check if the player is on the ground

    public AudioClip coinCollectSound;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Check if A or D key is pressed
        // A key has a negative value, D key has a positive value
        if (moveHorizontal != 0)
        {
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
            transform.Translate(movement * speed * Time.deltaTime);
        }

        // Check if the space bar is pressed and the player is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // Apply a force upwards
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // This function is called when the collider/rigidbody attached to this script
    // first touches another collider/rigidbody.
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // This function is called when the Collider other enters the trigger.
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "coin")
        {
            coinsCollected++;
            //coinsCollected = coinsCollected + 1;
            //coinsCollected += 1;
            
            AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);

            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {

    }
}
