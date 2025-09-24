using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;  // DOTweenを使うのに必要

public class StartButton : MonoBehaviour
{
    [SerializeField] public AudioSource bgmSource;//main camera
    [SerializeField] private AudioClip clipon;
    [SerializeField] private Button startButton;

    void Start()
    {
        if (startButton != null)
            startButton.onClick.AddListener(() =>
            {
                bgmSource.PlayOneShot(clipon);
            });
    }
    public void OnStartButtonClicked()
    {
        // ボタンを一瞬小さくしてから元に戻す
        transform.DOScale(.7f, .1f)   // 0.9倍に0.2秒かけて縮小
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                transform.DOScale(1f, .2f).SetEase(Ease.OutBounce);
            });

        // 1秒後にシーン遷移
        DOVirtual.DelayedCall(1f, () =>
        {
            SceneManager.LoadScene("SampleScene");
        });
    }

}
