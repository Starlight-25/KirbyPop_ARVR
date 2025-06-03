using System;
using System.IO;
using TMPro;
using UnityEngine;

public class MaxScoreManager : MonoBehaviour
{
    private string savePath;

    public TextMeshProUGUI[] MaxScoreText;

    
    private void Start()
    {
        savePath = Path.Combine(Application.persistentDataPath, "MaxScore.txt");
        if (!System.IO.File.Exists(savePath))
        {
            Debug.Log("0");
            System.IO.File.WriteAllText(savePath, "0");
            UpdateMaxScoreTMP(0);
        }
        else
        {
            UpdateMaxScoreTMP(int.Parse(GetMaxScore()));
        }
    }

    public string GetMaxScore() => System.IO.File.ReadAllText(savePath);

    
    
    
    
    public void SaveScore(int score)
    {
        if (score > int.Parse(GetMaxScore()))
        {
            System.IO.File.WriteAllText(savePath, score.ToString());
            UpdateMaxScoreTMP(score);
        }
    }

    
    
    
    
    private void UpdateMaxScoreTMP(int score)
    {
        foreach (TextMeshProUGUI maxscore in MaxScoreText)
        {
            maxscore.text = $"Max Score : {score}";
        }
    }
}