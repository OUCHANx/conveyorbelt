using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SEManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgmSource;  // カメラ用
    [SerializeField] private AudioSource sfxSource;  // 効果音用

    [SerializeField] private Button myButton;
    [SerializeField] private AudioClip clipon;
    [SerializeField] private AudioClip clipoff;
    private bool isOn = false;
    void Start()
    {
        //音を流したいけど音源が短いからループで流す
        bgmSource.loop = true;
        bgmSource.Play();
        if (myButton != null)
            myButton.onClick.AddListener(() => {
                isOn = !isOn;
                if (isOn)
                    sfxSource.PlayOneShot(clipon);
                else
                    sfxSource.PlayOneShot(clipoff);
            });
    }

    // Update is called once per frame
    void Update()
    {
    }
}
