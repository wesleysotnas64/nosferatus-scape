using System.Collections;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public bool isRandom;
    public float timeToActive;
    public float activeTime;
    public float activePosition;
    
    void Start()
    {
        // if (isRandom)
        // {
        //     timeToActive = Random.Range(1.0f, 5.0f);
        //     activeTime = Random.Range(1.0f, 2.0f);

        //     StartCoroutine(ActiveSpikeCoroutine());
        // }
    }

    public void ActiveSpike()
    {
        StartCoroutine(ActiveSpikeCoroutine());
    }

    private IEnumerator ActiveSpikeCoroutine()
    {
        yield return new WaitForSeconds(timeToActive);
        transform.position += new Vector3(0, activePosition,0);
        yield return new WaitForSeconds(activeTime);
        transform.position -= new Vector3(0, activePosition,0);
        Destroy(gameObject);
    }

    public IEnumerator ActiveCoroutine(float _toEnable, float _enable, float _disable)
    {
        yield return new WaitForSeconds(_toEnable);

        transform.position += new Vector3(0, activePosition,0);
        yield return new WaitForSeconds(_enable);

        transform.position -= new Vector3(0, activePosition,0);
        yield return new WaitForSeconds(_disable);

        Destroy(gameObject);
    }

}
