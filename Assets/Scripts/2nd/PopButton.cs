using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PopButton : MonoBehaviour
{
    [SerializeField] Image buttonImage;
    [SerializeField] float popScale = 1.2f;
    [SerializeField] float popDuration = 0.1f;
    Vector3 defaultScale = Vector3.one;

    void Awake()
    {
        if (buttonImage != null)
        {
            defaultScale = buttonImage.rectTransform.localScale;
        }
    }

    public void OnButtonPressed()
    {
        if (buttonImage == null) return;

        // ボタンが押されたときにポップアニメーションを実行（重複再生を防いでリセット）
        RectTransform rect = buttonImage.rectTransform;
        rect.DOKill(true);
        rect.localScale = defaultScale;
        rect.DOScale(defaultScale * popScale, popDuration)
            .SetEase(Ease.OutQuad)
            .SetLoops(2, LoopType.Yoyo);
    }
}
