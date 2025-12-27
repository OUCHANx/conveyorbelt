using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class PopButton : MonoBehaviour
{
    [SerializeField] Image buttonImage;
    [SerializeField] float popScale = 1.2f;
    [SerializeField] float popDuration = 0.1f;

    public void OnButtonPressed()
    {
        // ボタンが押されたときにポップアニメーションを実行
        buttonImage.GetComponent<RectTransform>().DOScale(popScale, popDuration).SetLoops(2, LoopType.Yoyo);
    }
}
