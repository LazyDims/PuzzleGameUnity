using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TMP_Text pieceCounterText;
    public WinPanelController winPanel;

    public int totalPiece;
    public int placedPiece;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GameObject[] pieces = GameObject.FindGameObjectsWithTag("PuzzlePiece");
        totalPiece = pieces.Length;
        placedPiece = 0;

        UpdatePieceCounter();
    }

    public void PiecePlaced()
    {
        placedPiece++;
        UpdatePieceCounter();

        if (placedPiece >= totalPiece)
        {
            WinGame();
        }
    }

    void UpdatePieceCounter()
    {
        pieceCounterText.text = $"{placedPiece}/{totalPiece}";
    }

    void WinGame()
    {
        winPanel.ShowWin(placedPiece, totalPiece);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}




