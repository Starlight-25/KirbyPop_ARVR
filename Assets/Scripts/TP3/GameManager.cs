using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score;
    private float lastSpawnTime;
    public UIManager UIManager;
    public TextMeshProUGUI ScoreText;
    public GameObject BasicKirbyPrefab;
    public GameObject BigKirbyPrefab;
    public Transform Camera;
    
    private float Cooldown;
    private float SpawnRange;
    
    void Start()
    {
        Time.timeScale = 0f;
    }
    void Update()
    {
        if (Time.timeScale != 0f)
        {
            if (Time.time - lastSpawnTime >= Cooldown)
            {
                SpawnEnemy(SpawnRange);
                lastSpawnTime = Time.time;
                GetSpawnTimeAndRange();
                Debug.Log("Spawned");
            }
        }
    }
    
    
    
    
    
    public void StartGame()
    {
        KillAllEnemies();
        Time.timeScale = 1f;
        Score = 0;
        ScoreText.text = $"Score : {Score}";
        lastSpawnTime = Time.time;
        Cooldown = 5f;
        SpawnRange = 10f;
    }


    private void KillAllEnemies()
    {
        GameObject[] Enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in Enemies)
        {
            Destroy(enemy);
        }   
    }

    
    

    private void GetSpawnTimeAndRange()
    {
        Cooldown -= (5 - 0.1f) / 99;
        if (Cooldown < 0.1f) Cooldown = 0.1f;

        SpawnRange -= (10 - 2f) / 99;
        if (SpawnRange < 2) SpawnRange = 2f;
    }
    
    
    
    
    
    public void SpawnEnemy(float distance)
    {
        float angle = Random.Range(0f, 360f);
        float x = Camera.position.x + distance * Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = Camera.position.y + -1.5f;
        float z = Camera.position.z + distance * Mathf.Sin(angle * Mathf.Deg2Rad);
        Vector3 spawnPos = new Vector3(x, y, z);
        
        GameObject Enemy = Random.Range(0, 101) <= 75 ? BasicKirbyPrefab : BigKirbyPrefab;
        
        Instantiate(Enemy, spawnPos, Quaternion.identity);
    }





    public void UpdateScore()
    {
        Score += 1;
        ScoreText.text = $"Score : {Score}";
    }
}
