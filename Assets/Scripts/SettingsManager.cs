using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;
    [SerializeField] private AudioMixer audioMixer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ApplyVolumeToMixer("Master");
        ApplyVolumeToMixer("BGM");
        ApplyVolumeToMixer("SE");
    }

    private void ApplyVolumeToMixer(string groupName)
    {
        string mixerParam = $"Volume_{groupName}";
        float savedVolume = PlayerPrefs.GetFloat(mixerParam, 1.0f);
        float dB = Mathf.Log10(Mathf.Clamp(savedVolume, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat(mixerParam, dB);
    }

    public void SetVolume(string groupName, float volume)
    {
        string mixerParam = $"Volume_{groupName}";
        float dB = Mathf.Log10(Mathf.Clamp(volume, 0.0001f, 1f)) * 20f;
        audioMixer.SetFloat(mixerParam, dB);
        PlayerPrefs.SetFloat(mixerParam, volume);
        PlayerPrefs.Save();
    }
}
