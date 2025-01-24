using System.Collections;
using UnityEngine;

public class Stake : MonoBehaviour
{
    public float timeToFall;

    private Rigidbody2D stakeRigidBody2D;
    void Start()
    {
        stakeRigidBody2D = GetComponent<Rigidbody2D>();
        stakeRigidBody2D.gravityScale = 0;
        timeToFall = Random.Range(0.25f, 3.0f);

        StartCoroutine(Fall());
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(timeToFall);
        stakeRigidBody2D.gravityScale = Random.Range(0.1f, 1.0f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }
}
