using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float forceJump;
    public bool inDash;
    public bool inGround;
    public float dashTime;
    public float dashDistance;
    public Vector2 direction;
    public float xRange;

    private Rigidbody2D playerRigidbody2D;
 
    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        direction = Vector2.right;
        inGround = false;
    }

    void Update()
    {
        PlayerControll();
    }

    private void PlayerControll()
    {
        if(!inDash)
        {
            if(Input.GetKey(KeyCode.A) && transform.position.x > -xRange) MoveSideBySide(-1);
            if(Input.GetKey(KeyCode.D) && transform.position.x <  xRange) MoveSideBySide( 1);

            if(Input.GetKeyDown(KeyCode.Space) && inGround) Jump();
        }

        if(Input.GetKeyDown(KeyCode.J)) StartCoroutine(DashCoroutine());
    }

    private void MoveSideBySide(int _direction)
    {
        transform.position += Time.deltaTime * _direction * speed * Vector3.right;
        direction = _direction > 0 ? Vector2.right : Vector2.left;
    }

    private void Jump()
    {
        playerRigidbody2D.velocity = Vector2.zero;
        playerRigidbody2D.AddForce(Vector2.up * forceJump);
    }

    private IEnumerator DashCoroutine()
    {
        if(!inDash)
        {
            inDash = true;

            playerRigidbody2D.gravityScale = 0;
            playerRigidbody2D.velocity = Vector2.zero;

            Vector2 initialPosition = transform.position;
            Vector2 finalPosition = initialPosition + (dashDistance*direction);

            if (finalPosition.x >  xRange) finalPosition.x =  xRange;
            if (finalPosition.x < -xRange) finalPosition.x = -xRange;

            float currentTime = 0.0f;
            while(currentTime<dashTime)
            {
                currentTime += Time.deltaTime;
                transform.position = Vector2.Lerp(initialPosition, finalPosition, currentTime/dashTime);
                yield return null;
            }
            transform.position = finalPosition;

            playerRigidbody2D.gravityScale = 1.0f;

            inDash = false;
        }
    }

}
