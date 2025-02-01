using System.Collections.Generic;
using UnityEngine;

public class StakeSpawner : MonoBehaviour
{
    public bool active;
    public GameObject stake;
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
        
        currentTime += Time.deltaTime;
        if (currentTime > spawnTime)
        {
            currentTime = 0;
            InstantitateStake();
        }
    }

    private void InstantitateStake()
    {
        if(Random.Range(0.0f, 1.0f) <= probabilitySpawn)
        {
            List<float> xPosition = new()
            {
              -0.8f, -0.7f, -0.6f, -0.5f, -0.4f, -0.3f, -0.2f, -0.1f, 0.0f,
               0.1f,  0.2f,  0.3f,  0.4f,  0.5f,  0.6f,  0.7f,  0.8f
            };
            int i = Random.Range(0, xPosition.Count);
            GameObject stakeGameObject = Instantiate(stake);
            stakeGameObject.transform.position = new Vector3(xPosition[i], transform.position.y, 0);
        }
    }
}
