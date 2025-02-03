using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    public GameObject tombstone;
    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag;

        switch (tag)
        {
            case "Stake":
                Instantiate(tombstone).transform.position = transform.position;
                gameObject.SetActive(false);
                break;

            default:
                break;

        }
    }
}
