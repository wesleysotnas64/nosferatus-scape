using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public int direction;
    private Vector3 vectorMove;
    void Start()
    {
        vectorMove = new Vector3(1, 0, 0);
    }

    void Update()
    {
        MoveSideBySide();
    }

    private void MoveSideBySide()
    {
        direction = 0;
        if(Input.GetKey(KeyCode.A)) direction = -1;
        if(Input.GetKey(KeyCode.D)) direction =  1;
        transform.position += Time.deltaTime * direction * speed * vectorMove;
    }
}
