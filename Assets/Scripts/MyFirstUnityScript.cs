using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstUnityScript : MonoBehaviour
{
    [SerializeField] private Transform testCube;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float turnSpeed;

    //Global variable
    [SerializeField] private int numberOne = 5;
    [SerializeField]
    private int numberTwo = 7;

    RandomClass rndClass;
    MyFirstScript myFirstScrit;

    MeshRenderer custmRenderer;

    //Rigidbody rb;

    // Update is called once per frame
    void Update()
    {
        //Moving object without physics
        //testCube.Translate(testCube.forward * moveSpeed * Time.deltaTime);

        testCube.Rotate(Vector3.up * turnSpeed *Time.deltaTime);

        /*if(numberOne > numberTwo)
        {
            Debug.Log("Hello Running!");
        }
        else if(numberOne == numberTwo)
        {
            Debug.Log("Number one = number two");
        }
        else if (numberOne < numberTwo)
        {
            Debug.Log("Number one = number two");
        }
        else if (numberOne != numberTwo)
        {
            Debug.Log("Number one = number two");
        }
        else
        {

        }

        if(numberTwo > numberOne || numberOne < rndClass.newNumber)
        {

        }*/

        if(Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("Key A is beig pressed");
        }

        /*float mouseX = Input.GetAxis("Mouse X");
        Debug.Log(mouseX);*/
    }

    void Start()
    {
        int total = 0;
        total = rndClass.newNumber;
            //= numberOne + numberTwo;
        Debug.Log("Total = " + total);

        custmRenderer.material.color = Color.red;
        //rb.useGravity = true;
        myFirstScrit.isGameStart = false;

        Debug.Log("Hello World!");
    }

    private void FixedUpdate()
    {
        
    }
}


public class RandomClass
{
    public int newNumber = 7;
}
