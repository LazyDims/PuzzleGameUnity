using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int score = 0;

    public TMP_Text pieceCounterText;

    void Awake()
    {
        instance = this;
    }

    public void AddScore(string name)
    {
        score++;
        Debug.Log(name + " benar! Score: " + score);
    }

    public void UpdatePieceCounter(int placed, int total)
    {
        pieceCounterText.text = $"Piece {placed}/{total}";
    }
}
