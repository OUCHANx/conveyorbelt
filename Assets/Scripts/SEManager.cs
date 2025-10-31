using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SEManager : MonoBehaviour
{
    public static SEManager Instance;
    [SerializeField] private Button onoffButton;
    [SerializeField] private AudioClip panClickClip;
    [SerializeField] private AudioClip clipon;
    [SerializeField] private AudioClip clipoff;

    [SerializeField] private AudioSource audioSource;
    private bool isOn = false;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        //音を流したいけど音源が短いからループで流す
        audioSource.loop = true;
        audioSource.Play();
        if (onoffButton != null)
            onoffButton.onClick.AddListener(() =>
            {
                isOn = !isOn;
                if (isOn)
                {
                    isOn1();
                }
                else
                {
                    isOff1();
                }
            });
    }

    public void PlaySE(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    //パンをクリックした時の音　clickはSimpleLineMover.csから呼ばれる
    public void click() => PlaySE(panClickClip);
    //Onの時の音 このスクリプトから呼ばれる
    public void isOn1() => PlaySE(clipon);
    //Offの時の音 このスクリプトから呼ばれる
    public void isOff1() => PlaySE(clipoff);
}
