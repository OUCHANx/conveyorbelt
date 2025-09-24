using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    [SerializeField] public AudioSource bgmSource;//main camera
    [SerializeField] private AudioClip clipon;
    [SerializeField] private Button startButton;
    [SerializeField] private SimpleFadeOut transition;


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
    // ボタンアニメーション
    transform.DOScale(.5f, .1f).SetEase(Ease.OutQuad)
        .OnComplete(() => transform.DOScale(1f, .2f).SetEase(Ease.OutBounce));

    // フェードアウトで遷移
    transition.FadeAndLoad("SampleScene", 0.7f);
}


}
