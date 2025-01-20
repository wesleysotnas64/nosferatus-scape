using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float forceJump;

    private Rigidbody2D playerRigidbody2D;
 
    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerControll();
    }

    private void PlayerControll()
    {
        if(Input.GetKey(KeyCode.A)) MoveSideBySide(-1);
        if(Input.GetKey(KeyCode.D)) MoveSideBySide( 1);

        if(Input.GetKeyDown(KeyCode.Space)) Jump();
    }

    private void MoveSideBySide(int _direction)
    {
        transform.position += Time.deltaTime * _direction * speed * Vector3.right;
    }

    private void Jump()
    {
        playerRigidbody2D.velocity = Vector2.zero;
        playerRigidbody2D.AddForce(Vector2.up * forceJump);
    }

}
