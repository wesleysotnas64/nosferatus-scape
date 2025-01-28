using UnityEngine;

public class SceneController : MonoBehaviour
{
    public int maxLevel;
    public int currentLevel;
    public float pointTime;
    public float currentTime;
    public float nextLevelTime;

    void Start()
    {
        maxLevel = 5;
        currentLevel = 1;
        pointTime = 0;
        currentTime = 0;
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
            }
        }
    }
}
