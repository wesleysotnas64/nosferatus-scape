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
        
        currentTime += Time.deltaTime;
        if (currentTime > spawnTime)
        {
            currentTime = 0;
            InstantitateSpikeTrap();
        }
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
}
