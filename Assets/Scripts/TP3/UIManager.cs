using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject StartCanvas;
    public GameObject InGameCanvas;
    public GameObject PauseCanvas;
    public GameObject ResultCanvas;
    public GameManager GameManager;
    
    
    
    public void StartButtonClicked()
    {
        GameManager.StartGame();
        StartCanvas.SetActive(false);
        InGameCanvas.SetActive(true);
    }

    public void PauseButtonClicked()
    {
        Time.timeScale = 0f;
        InGameCanvas.SetActive(false);
        PauseCanvas.SetActive(true);
    }

    public void ResumeButtonClicked()
    {
        Time.timeScale = 1f;
        PauseCanvas.SetActive(false);
        InGameCanvas.SetActive(true);
    }

    public void RestartButtonClicked()
    {
        Time.timeScale = 1f;
        ResultCanvas.SetActive(false);
        InGameCanvas.SetActive(true);
        GameManager.StartGame();
    }
    

    public void QuitButtonClicked() => Application.Quit();


    public void ResultCanvasShow()
    {
        GameManager.transform.GetComponent<MaxScoreManager>().SaveScore(GameManager.Score);
        
        Time.timeScale = 0f;
        TextMeshProUGUI ScoreTMP = ResultCanvas.transform.Find("ScoreTMP").GetComponent<TextMeshProUGUI>();
        ScoreTMP.text = GameManager.ScoreText.text;

        InGameCanvas.SetActive(false);
        ResultCanvas.SetActive(true);
    }
}
