using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SEManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgmSource;  // カメラ用
    [SerializeField] private AudioSource sfxSource;  // 効果音用

    [SerializeField] private Button onoffButton;
    [SerializeField] private AudioClip clipon;
    [SerializeField] private AudioClip clipoff;
    [SerializeField] private AudioClip clickClip;
    private bool isOn = false;
    void Start()
    {
        //音を流したいけど音源が短いからループで流す
        bgmSource.loop = true;
        bgmSource.Play();
        if (onoffButton != null)
            onoffButton.onClick.AddListener(() =>
            {
                isOn = !isOn;
                if (isOn)
                    sfxSource.PlayOneShot(clipon);
                else
                    sfxSource.PlayOneShot(clipoff);
            });
    }

    public void PlaySE(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void click() => PlaySE(clickClip);
}
