using UnityEngine;
using TMPro;
using System.Collections;

public class WinPanelController : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public Transform winBox;
    public TMP_Text scoreText;

    public GameObject confetti1;
    public GameObject confetti2;

    void Start()
    {
        canvasGroup.alpha = 0;
        winBox.localScale = Vector3.zero;
    }

    public void ShowWin(int placed, int total)
    {
        gameObject.SetActive(true);

        canvasGroup.alpha = 0;
        winBox.localScale = Vector3.zero;

        scoreText.text = $"Score : {placed}/{total}";

        StartCoroutine(WinAnimation());
    }

    IEnumerator WinAnimation()
    {
        confetti1.SetActive(true);
        confetti2.SetActive(true);

        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * 3f;
            canvasGroup.alpha = t;
            winBox.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            yield return null;
        }
    }
    public void OnRestartButton()
    {
        GameManager.instance.RestartGame();
    }
}
