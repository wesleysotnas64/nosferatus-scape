using UnityEngine;

public class FootSensor : MonoBehaviour
{
    private PlayerMovement player;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.GetComponent<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        string tag = other.gameObject.tag;
        switch (tag)
        {
            case "Ground":
                player.inGround = true;
                active = true;
                break;

            default:
                break;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        string tag = other.gameObject.tag;
        switch (tag)
        {
            case "Ground":
                player.inGround = false;
                active = false;
                break;

            default:
                break;
        }
    }
}
