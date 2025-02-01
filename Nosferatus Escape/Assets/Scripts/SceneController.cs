using UnityEngine;

public class SceneController : MonoBehaviour
{
    public int maxLevel;
    public int currentLevel;
    public float pointTime;
    public float currentTime;
    public float nextLevelTime;

    private StakeSpawner stakeSpawner;
    private SpikeTrapSpawner spikeTrapSpawner;

    void Start()
    {
        maxLevel = 5;
        currentLevel = 1;
        pointTime = 0;
        currentTime = 0;

        stakeSpawner = GameObject.Find("StakeSpawner").GetComponent<StakeSpawner>();
        spikeTrapSpawner = GameObject.Find("SpikeTrapSpawner").GetComponent<SpikeTrapSpawner>();

        stakeSpawner.active = true;
        spikeTrapSpawner.active = false;
    }

    void Update()
    {
        UpdateTimeAndPoints();
    }

    private void UpdateTimeAndPoints()
    {
        pointTime += Time.deltaTime;
        if(currentLevel < maxLevel)
        {
            currentTime += Time.deltaTime;
            if(currentTime > nextLevelTime)
            {
                currentTime = 0;
                currentLevel++;
                SetLevel(currentLevel);
            }
        }
    }

    private void SetLevel(int level)
    {
        switch(level)
        {
            case 1:
                stakeSpawner.spawnTime = 3.0f;
                break;

            case 2:
                stakeSpawner.spawnTime = 1.5f;
                spikeTrapSpawner.active = true;
                spikeTrapSpawner.spawnTime = 5.0f;
                break;

            case 3:
                stakeSpawner.spawnTime = 1.0f;
                spikeTrapSpawner.spawnTime = 2.5f;
                break;

            case 4:
                stakeSpawner.spawnTime = 0.75f;
                break;

            case 5:
                stakeSpawner.spawnTime = 0.5f;
                break;

            default:
                break;
        }
    }
}
