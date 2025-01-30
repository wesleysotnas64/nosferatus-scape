using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SpikeTrapSpawner : MonoBehaviour
{

    public bool active;
    public GameObject spikeTrap;
    public float spawnTime;
    public float currentTime;
    [Range(0, 1)]
    public float probabilitySpawn;
    public float spawAreaRange;

    void Start()
    {
        // active = false;
    }

    void Update()
    {
        if (!active) return; //Impede de executar as demais funções se não tiver ativo
        
        // currentTime += Time.deltaTime;
        // if (currentTime > spawnTime)
        // {
        //     currentTime = 0;
        //     InstantitateSpikeTrap();
        // }

        if (Input.GetKeyDown(KeyCode.P)) StartCoroutine(InstantiateLeftToRightSpikesCoroutine(0.5f));
        if (Input.GetKeyDown(KeyCode.O)) StartCoroutine(InstantiateRightToLeftSpikesCoroutine(0.5f));
    }

    private void InstantitateSpikeTrap()
    {
        if(Random.Range(0.0f, 1.0f) <= probabilitySpawn)
        {
            float xPosition = Random.Range(-spawAreaRange, spawAreaRange);
            GameObject stakeGameObject = Instantiate(spikeTrap);
            stakeGameObject.transform.position = new Vector3(xPosition, transform.position.y, 0);
        }
    }

    private IEnumerator InstantiateLeftToRightSpikesCoroutine(float _velocity = 1.0f)
    {
        List<float> xPosition = new() { -0.8f, -0.6f, -0.4f, -0.2f, 0.0f, 0.2f, 0.4f, 0.6f, 0.8f };
        float waitTime = 0.5f * _velocity;
        Vector3 spikeTrapParam = new(0.25f, 0.5f, 0.25f);
        spikeTrapParam *= _velocity;

        for(int i = 0; i < xPosition.Count; i++)
        {
            GameObject spikeTrapGO = Instantiate(spikeTrap);
            spikeTrapGO.transform.position = new Vector3(xPosition[i], transform.position.y, 0);
            StartCoroutine(
                spikeTrapGO.GetComponent<SpikeTrap>().ActiveCoroutine(
                    spikeTrapParam.x, spikeTrapParam.y, spikeTrapParam.z));
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator InstantiateRightToLeftSpikesCoroutine(float _velocity = 1.0f)
    {
        List<float> xPosition = new() { -0.8f, -0.6f, -0.4f, -0.2f, 0.0f, 0.2f, 0.4f, 0.6f, 0.8f };
        float waitTime = 0.5f * _velocity;
        Vector3 spikeTrapParam = new(0.25f, 0.5f, 0.25f);
        spikeTrapParam *= _velocity;

        for(int i = xPosition.Count-1; i >= 0; i--)
        {
            GameObject spikeTrapGO = Instantiate(spikeTrap);
            spikeTrapGO.transform.position = new Vector3(xPosition[i], transform.position.y, 0);
            StartCoroutine(
                spikeTrapGO.GetComponent<SpikeTrap>().ActiveCoroutine(
                    spikeTrapParam.x, spikeTrapParam.y, spikeTrapParam.z));
            yield return new WaitForSeconds(waitTime);
        }
    }
}
