using UnityEditor.SearchService;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    public SceneController sceneController;
    void OnCollisionEnter2D(Collision2D col)
    {
        string tag = col.gameObject.tag;

        switch (tag)
        {
            case "Stake":
                sceneController.GameOver();
                break;

            default:
                break;

        }
    }
}
