using TMPro;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public int maxLevel;
    public int currentLevel;
    public float score;
    public float currentTime;
    public float nextLevelTime;
    public bool isActiveGameplay;

    private StakeSpawner stakeSpawner;
    private SpikeTrapSpawner spikeTrapSpawner;

    public GameObject player;
    public GameObject tombstone;
    public GameObject canvasMenu;

    public TMP_Text textLevel;
    public TMP_Text textScore;
    public TMP_Text textHighScore;

    void Start()
    {
        maxLevel = 5;
        currentLevel = 1;
        score = 0;
        currentTime = 0;
        isActiveGameplay = false;

        textHighScore.text = $"High Score: {PlayerPrefs.GetFloat("HighScore"):F2}";

        stakeSpawner = GameObject.Find("StakeSpawner").GetComponent<StakeSpawner>();
        spikeTrapSpawner = GameObject.Find("SpikeTrapSpawner").GetComponent<SpikeTrapSpawner>();

        stakeSpawner.isActive = false;
        spikeTrapSpawner.active = false;
    }

    void Update()
    {
        if(isActiveGameplay) UpdateTimeAndPoints();
        UpdateCanvas();
    }

    private void UpdateCanvas()
    {
        textLevel.text = $"Level: {currentLevel}";
        textScore.text = $"Score: {score:F2}";
    }

    private void UpdateTimeAndPoints()
    {
        score += Time.deltaTime;
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
                // spikeTrapSpawner.active = true;
                // spikeTrapSpawner.spawnTime = 5.0f;
                break;

            case 3:
                stakeSpawner.spawnTime = 1.0f;
                // spikeTrapSpawner.spawnTime = 2.5f;
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

    public void InitGameplay()
    {
        ResetAttributes();

        isActiveGameplay = true;

        tombstone.SetActive(false);

        player.SetActive(true);
        player.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        player.GetComponent<PlayerMovement>().Reset();
        player.GetComponent<PlayerMovement>().isActiveMovement = true;
        
        canvasMenu.SetActive(false);

        stakeSpawner.isActive = true;
    }

    public void GameOver()
    {
        if(score > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", score);
            textHighScore.text = $"High Score: {PlayerPrefs.GetFloat("HighScore"):F2}";
        }

        isActiveGameplay = false;

        canvasMenu.SetActive(true);

        tombstone.SetActive(true);
        tombstone.transform.position = player.transform.position;

        player.GetComponent<PlayerMovement>().isActiveMovement = false;
        player.SetActive(false);

        stakeSpawner.isActive = false;
    }

    private void ResetAttributes()
    {
        maxLevel = 5;
        currentLevel = 1;
        score = 0;
        currentTime = 0;
    }
}
