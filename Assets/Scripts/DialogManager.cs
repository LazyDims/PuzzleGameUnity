using TMPro;
using UnityEngine;
using System.Collections;

public class DialogManager : MonoBehaviour
{
    public TMP_Text dialogText;
    public string[] dialogLines;
    public float typingSpeed = 0.04f;

    int index;
    bool isTyping;

    void Start()
    {
        Time.timeScale = 0f;
        gameObject.SetActive(true);
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogText.text = "";

        foreach (char c in dialogLines[index])
        {
            dialogText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    public void NextDialog()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogText.text = dialogLines[index];
            isTyping = false;
            return;
        }

        if (index < dialogLines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
        }
        else
        {
            StartCoroutine(CloseDialog());
        }
    }

    IEnumerator CloseDialog()
    {
        Time.timeScale = 1f;
        yield return new WaitForSeconds(0.3f);
        gameObject.SetActive(false);
    }
}
