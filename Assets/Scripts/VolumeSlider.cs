using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    //[SerializeField] private Slider masterSlider;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;

    void Start()
    {
        //float master = PlayerPrefs.GetFloat("Volume_Master", 1.0f);
        float bgm = PlayerPrefs.GetFloat("Volume_BGM", 1.0f);
        float se = PlayerPrefs.GetFloat("Volume_SE", 1.0f);

        //スライダー位置変更
        //masterSlider.value = master;
        bgmSlider.value = bgm;
        seSlider.value = se;

        //mixer値変更
        //SettingsManager.Instance.SetVolume("Master", master);
        SettingsManager.Instance.SetVolume("BGM", bgm);
        SettingsManager.Instance.SetVolume("SE", se);

        //変更時にSettingsManagerへ通知
        //masterSlider.onValueChanged.AddListener (v => SettingsManager.Instance.SetVolume("Master", v));
        bgmSlider.onValueChanged.AddListener (v => SettingsManager.Instance.SetVolume("BGM", v));
        seSlider.onValueChanged.AddListener (v => SettingsManager.Instance.SetVolume("SE", v));
    }



}
