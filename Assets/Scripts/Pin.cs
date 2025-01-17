using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    public bool isFallen;

    private Vector3 startPosition;
    private Quaternion startRotation;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Quaternion.Angle(startRotation, transform.localRotation) > 5f)
        {
            isFallen = true;
        }
        else
        {
            isFallen = false;
        }*/

        if(gameObject.activeSelf)
        {
            isFallen = Quaternion.Angle(startRotation, transform.localRotation) > 5f;
        }
        
    }

    public void ResetPin()
    {
        gameObject.SetActive(true);
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;


        transform.position = startPosition+Vector3.up*0.01f;
        transform.rotation = startRotation;
        isFallen = false;
        rb.isKinematic = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("pit"))
        {
            isFallen = true;
        }
    }
}
