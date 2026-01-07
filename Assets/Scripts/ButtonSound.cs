using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public void PlayClick()
    {
        AudioManager.instance.PlaySFX(
            AudioManager.instance.buttonClick
        );
    }
}
