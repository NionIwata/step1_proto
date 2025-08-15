using UnityEngine;

public class BGMFadeController : MonoBehaviour
{
    public AudioSource bgmSource;
    public float fadeSpeed = 0.2f;
    private bool fadeIn = false;

    void Update()
    {
        if (fadeIn && bgmSource != null)
        {
            bgmSource.volume += fadeSpeed * Time.deltaTime;
            bgmSource.volume = Mathf.Clamp01(bgmSource.volume);
        }
    }

    public void StartFadeIn()
    {
        fadeIn = true;
    }
}
