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
        player.inGround = true;
        active = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        player.inGround = false;
        active = false;
    }
}
