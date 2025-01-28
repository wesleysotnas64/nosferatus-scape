using System.Collections;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public bool isRandom;
    public float timeToActive;
    public float activeTime;
    public float activePosition;
    private BoxCollider2D boxCollider2D;
    
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        if (isRandom)
        {
            timeToActive = Random.Range(1.0f, 5.0f);
            activeTime = Random.Range(1.0f, 2.0f);

            StartCoroutine(ActiveSpikeCoroutine());
        }
    }

    private IEnumerator ActiveSpikeCoroutine()
    {
        boxCollider2D.enabled = false;
        yield return new WaitForSeconds(timeToActive);
        boxCollider2D.enabled = true;
        transform.position += new Vector3(0, activePosition,0);
        yield return new WaitForSeconds(activeTime);
        transform.position -= new Vector3(0, activePosition,0);
        Destroy(gameObject);
    }

    public void ActiveSpike()
    {
        StartCoroutine(ActiveSpikeCoroutine());
    }
}
