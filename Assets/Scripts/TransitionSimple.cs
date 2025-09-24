using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class SimpleFadeOut : MonoBehaviour
{
    [SerializeField] private Image fade;
    public void FadeAndLoad(string sceneName, float duration = 0.5f)
    {
        if (fade == null) return;

        fade.raycastTarget = true;
        fade.DOFade(1f, duration).SetEase(Ease.InQuad)
            .OnComplete(() =>
            {
                SceneManager.LoadScene(sceneName);
            });
    }

    void Awake()
    {
        if (fade != null)
        {
            var c = fade.color; c.a = 0f; fade.color = c;
            fade.raycastTarget = false;
        }
    }
}
