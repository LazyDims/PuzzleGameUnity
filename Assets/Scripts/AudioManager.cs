using UnityEngine;

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

    // 🎵 BGM
    public void PlayBGM(AudioClip clip)
    {
        if (bgmSource.clip == clip) return;

        bgmSource.clip = clip;
        bgmSource.Play();
    }

    // 🔊 SFX
    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
