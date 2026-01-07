using TMPro;
using UnityEngine;
using System.Collections;

public class ChecklistItemUI : MonoBehaviour
{
    public TMP_Text cityNameText;

    RectTransform rect;

    Color defaultColor = Color.white;
    Color doneColor = new Color(0.2f, 0.8f, 0.2f);

    void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    public void Setup(string cityName)
    {
        cityNameText.text = cityName;

        cityNameText.color = defaultColor;
        cityNameText.alpha = 0.6f;

        rect.localScale = Vector3.one;
    }

    public void SetChecked()
    {
        StopAllCoroutines();
        StartCoroutine(BounceAnim());
    }

    IEnumerator BounceAnim()
    {
        float duration = 0.15f;

        yield return ScaleTo(1.2f, duration);
        yield return ScaleTo(1f, duration);

        cityNameText.color = doneColor;
        cityNameText.alpha = 1f;
    }

    IEnumerator ScaleTo(float target, float duration)
    {
        float t = 0f;
        Vector3 start = rect.localScale;
        Vector3 end = Vector3.one * target;

        while (t < duration)
        {
            t += Time.deltaTime;
            float p = t / duration;

            rect.localScale = Vector3.Lerp(start, end, p);
            cityNameText.color = Color.Lerp(defaultColor, doneColor, p);
            cityNameText.alpha = Mathf.Lerp(0.6f, 1f, p);

            yield return null;
        }

        rect.localScale = end;
    }
}
