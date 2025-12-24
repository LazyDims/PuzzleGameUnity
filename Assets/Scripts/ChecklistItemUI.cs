using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChecklistItemUI : MonoBehaviour
{
    public TMP_Text cityNameText;
    // public Image checkIcon;

    public string CityName { get; private set; }

    public void Setup(string cityName)
    {
        CityName = cityName;
        cityNameText.text = cityName;

        // checkIcon.gameObject.SetActive(false);
        // checkIcon.transform.localScale = Vector3.zero;
    }

    public void SetChecked()
    {
        // checkIcon.gameObject.SetActive(true);
        StartCoroutine(CheckAnim());
    }

    IEnumerator CheckAnim()
    {
        float t = 0f;
        float duration = 0.2f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float scale = Mathf.Lerp(0f, 1.2f, t / duration);
            // checkIcon.transform.localScale = Vector3.one * scale;
            yield return null;
        }

        // settle ke normal
        // checkIcon.transform.localScale = Vector3.one;

        // Optional: ubah warna text
        cityNameText.color = new Color(0.2f, 0.7f, 0.2f);
    }
}
