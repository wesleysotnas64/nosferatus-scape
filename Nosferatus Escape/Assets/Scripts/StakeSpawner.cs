using UnityEngine;

public class StakeSpawner : MonoBehaviour
{
    public GameObject stake;
    public float spawnTime;
    public float currentTime;
    [Range(0, 1)]
    public float probabilitySpawn;
    public int spawAreaRange;

    void Update()
    {
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
            float xPosition = Random.Range(-spawAreaRange, spawAreaRange+1);
            GameObject stakeGameObject = Instantiate(stake);
            stakeGameObject.transform.position = new Vector3(xPosition, transform.position.y, 0);
        }
    }
}
