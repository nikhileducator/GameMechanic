using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public int coinsCollected = 0;

    public AudioClip coinCollectSound;

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
    }

    // This function is called when the collider/rigidbody attached to this script
    // first touches another collider/rigidbody.
    private void OnCollisionEnter(Collision collision)
    {
        // Output the name of the object that collided with this one
        Debug.Log("Collision detected with " + collision.gameObject.name);
        
        // You can add more logic here to handle the collision as needed
    }

    // This function is called every frame while the collider/rigidbody is touching
    // another collider/rigidbody.
    private void OnCollisionStay(Collision collision)
    {
        // You can implement repeated behavior while in contact if needed
    }

    // This function is called when the collider/rigidbody attached stops touching another
    // collider/rigidbody.
    private void OnCollisionExit(Collision collision)
    {
        // Handle logic for when the collision ends
        Debug.Log("Stopped colliding with " + collision.gameObject.name);
    }

    // This function is called when the Collider other enters the trigger.
    private void OnTriggerEnter(Collider other)
    {
        // Output the name of the object that entered the trigger
        Debug.Log("Trigger entered by " + other.gameObject.name);

        if(other.gameObject.tag == "coin")
        {
            coinsCollected++;
            //coinsCollected = coinsCollected + 1;
            //coinsCollected += 1;
            
            AudioSource.PlayClipAtPoint(coinCollectSound, transform.position);

            Destroy(other.gameObject);
        }

        // Add additional logic to handle entering the trigger
    }

    // This function is called once per frame for every Collider other
    // that is touching the trigger.
    private void OnTriggerStay(Collider other)
    {
        // You can implement continued behavior while the object stays in the trigger
    }

    // This function is called when the Collider other has stopped touching the trigger.
    private void OnTriggerExit(Collider other)
    {
        // Handle logic for when an object exits the trigger
        Debug.Log("Trigger exited by " + other.gameObject.name);
    }
}
