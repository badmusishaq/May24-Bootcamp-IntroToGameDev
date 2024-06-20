using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody[] balls;
    [SerializeField] Transform throwingArrow;
    [SerializeField] Animator arrowAnimator;
    [SerializeField] Transform ballSpawnPoint;

    public float throwForce;
    public float playerMoveSpeed;
    public float arrowMinXValue, arrowMaxXValue;

    private bool wasBallThrown; //default value of a boolean variable is false
    //private Vector3 ballDefaultPosition;
    private Vector3 ballOffset;
    private Rigidbody selectedBall;

    // Start is called before the first frame update
    void Start()
    {
        ballOffset = ballSpawnPoint.position - throwingArrow.position;

        StartThrow();
    }

    // Update is called once per frame
    void Update()
    {
        TryMoveArrow();
        TryThrowBall();
    }

    public void StartThrow()
    {
        arrowAnimator.SetBool("Aiming", true);
        wasBallThrown = false;

        int randomBall = Random.Range(0, balls.Length);
        selectedBall = Instantiate(balls[randomBall], ballSpawnPoint.position, Quaternion.identity);
    }

    public void TryMoveArrow()
    {
        if(!wasBallThrown)
        {
            //throwingArrow.position += throwingArrow.right * Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime;

            float movePosition = Input.GetAxis("Horizontal") * playerMoveSpeed * Time.deltaTime;
            throwingArrow.position = new Vector3(Mathf.Clamp(throwingArrow.position.x + movePosition, arrowMinXValue, arrowMaxXValue),
                throwingArrow.position.y, throwingArrow.position.z);

            //Make ball follow the arrow by putting the ball in the same position everytime the arrow moves + the offset/distance
            selectedBall.transform.position = throwingArrow.position + ballOffset;
        }
    }

    public void TryThrowBall()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            selectedBall.AddForce(throwingArrow.forward * throwForce, ForceMode.Impulse);
            wasBallThrown = true;
            arrowAnimator.SetBool("Aiming", false);
        }
    }
}
