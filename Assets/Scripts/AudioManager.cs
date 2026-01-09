using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    [Header("BGM")]
    public AudioClip idleBGM;

    [Header("SFX")]
    public AudioClip buttonClick;
    public AudioClip pauseSound;
    public AudioClip resumeSound;
    public AudioClip winSound;

    Coroutine bgmFadeCoroutine;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            PlayBGM(idleBGM);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 🎵 PLAY BGM
    public void PlayBGM(AudioClip clip)
    {
        if (bgmSource.clip == clip && bgmSource.isPlaying) return;

        bgmSource.clip = clip;
        bgmSource.volume = 1f;
        bgmSource.Play();
    }

    // ⏸ STOP BGM (langsung)
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    // 🎶 FADE OUT BGM
    public void FadeOutBGM(float duration = 0.5f)
    {
        if (bgmFadeCoroutine != null)
            StopCoroutine(bgmFadeCoroutine);

        bgmFadeCoroutine = StartCoroutine(FadeBGM(0f, duration));
    }

    IEnumerator FadeBGM(float targetVolume, float duration)
    {
        float startVolume = bgmSource.volume;
        float t = 0f;

        while (t < duration)
        {
            t += Time.unscaledDeltaTime;
            bgmSource.volume = Mathf.Lerp(startVolume, targetVolume, t / duration);
            yield return null;
        }

        bgmSource.volume = targetVolume;

        if (targetVolume == 0f)
            bgmSource.Stop();
    }

    // 🔊 SFX
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
