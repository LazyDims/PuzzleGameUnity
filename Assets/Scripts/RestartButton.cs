using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // public void OnRestartButton()
    // {
    //     GameManager.instance.RestartGame();
    // }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Next Level");
    }
}