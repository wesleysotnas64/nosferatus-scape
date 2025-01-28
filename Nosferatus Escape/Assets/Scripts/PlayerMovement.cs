using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float forceJump;
    public float dashRecoverTime;
    public float dashDistance;
    public float xRange;
    public bool inDash;
    public bool enabledDash;
    public bool inGround;
    public float dashTime;
    public int dashDirection;
    public Vector2 direction;

    private Rigidbody2D playerRigidbody2D;
    private SpriteRenderer playerSpriteRenderer;
 
    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        direction = Vector2.right;
        inGround = false;
        enabledDash = true;
        dashDirection = 1;
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

        if(Input.GetKeyDown(KeyCode.J) && enabledDash) StartCoroutine(DashCoroutine());
    }

    private void MoveSideBySide(int _direction)
    {
        transform.position += Time.deltaTime * _direction * speed * Vector3.right;
        direction = _direction > 0 ? Vector2.right : Vector2.left;
        playerSpriteRenderer.flipX = _direction != 1;
        dashDirection = _direction;
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
            enabledDash = false;

            playerRigidbody2D.gravityScale = 0;
            playerRigidbody2D.velocity = Vector2.zero;

            Vector2 initialPosition = transform.position;
            Vector2 finalPosition = initialPosition + new Vector2(dashDistance*dashDirection, 0);

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

            StartCoroutine(DashRecoverCoroutine());
        }
    }

    private IEnumerator DashRecoverCoroutine()
    {
        float h = 275.0f/360.0f;
        float s = 50.0f/100.0f;
        float v = 100.0f/100.0f;
        playerSpriteRenderer.color = Color.HSVToRGB(h, s, v);

        enabledDash = false;
        float currentTime = 0.0f;
        while(currentTime < dashRecoverTime)
        {
            currentTime += Time.deltaTime;
            yield return null;
        }
        enabledDash = true;

        playerSpriteRenderer.color = Color.white;
    }
}
