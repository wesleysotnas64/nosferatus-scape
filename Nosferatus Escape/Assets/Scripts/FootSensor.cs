using UnityEngine;

public class FootSensor : MonoBehaviour
{
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        player.inGround = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        player.inGround = false;
    }
}
