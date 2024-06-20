using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Check collison on all colliders in contact
        //Debug.Log("Ball collided with " + collision.gameObject.name);

        if(collision.gameObject.CompareTag("pin"))
        {
            //Check for collision object with the "pin" tag only
            //Debug.Log("Collided with a pin");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collided with a trigger");

        //Start the next throw when the ball enters the pit
        manager.SetNextThrow();

        //Destroy or delete the ball that just entered the pit
        Destroy(gameObject);
    }
}
