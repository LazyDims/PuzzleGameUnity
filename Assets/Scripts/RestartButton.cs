using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void LoadNextLevel()
    {
        SceneManager.LoadScene("Next Level");
    }
}