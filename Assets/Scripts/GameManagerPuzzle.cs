using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddScore(string name)
    {
        score++;
        Debug.Log(name + " benar! Score: " + score);
    }
}
