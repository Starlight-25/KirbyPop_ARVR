using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScenes : MonoBehaviour
{
    private void LoadAScene(int buildIndex) {
        SceneManager.LoadScene(buildIndex, LoadSceneMode.Single);
    }
    
    public void LoadMenu()
    {
        LoadAScene(0);
    }
    public void LoadScene1()
    {
        LoadAScene(1);
    }
    
    public void LoadScene2() {
        LoadAScene(2);
    }
    
    public void QuitGame()
    {
        Debug.Log("Game is closing..."); // Just to confirm it's working in the editor
        Application.Quit();
    }
}
