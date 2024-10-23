using Challenge;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource bgmSource;

    public void PlayBgm()
    {
        Debug.Log("Play Bgm");
        bgmSource.Play();
    }

    public void StopBgm()
    {
        Debug.Log("Stop Bgm");
        bgmSource.Stop();
    }
}