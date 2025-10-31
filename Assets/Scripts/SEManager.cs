using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SEManager : MonoBehaviour
{
    public static SEManager Instance;
    [SerializeField] private AudioSource bgmSource;  // カメラ用
    [SerializeField] private AudioSource sfxSource;  // 効果音用

    [SerializeField] private Button onoffButton;
    [SerializeField] private AudioClip clickClip;
    [SerializeField] private AudioClip clipon;
    [SerializeField] private AudioClip clipoff;
    private bool isOn = false;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject); // 必要なければ削除して可
    }
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
    //パンをクリックした時の音　clickはSimpleLineMover.csから呼ばれる
    public void click() => PlaySE(clickClip);
    //Onの時の音 このスクリプトから呼ばれる
    public void isOn() => PlaySE(clipon);
    //Offの時の音 このスクリプトから呼ばれる
    public void isOff() => PlaySE(clipoff);
}
