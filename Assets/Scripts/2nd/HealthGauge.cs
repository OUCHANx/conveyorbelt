using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Scripting.APIUpdating;


public class HealthGauge : MonoBehaviour
{
    public HealthGauge healthGauge;
    public secondSimpleLineMover SimpleLineMover;
    [SerializeField] private Image healthImage;
    [SerializeField] private Image burnImage;
    public float duration = 0.5f; //０.５秒でヘルスが減るアニメーションを実行
    public float debugDamageRate = 0.2f;
    public float currentRate = 1.0f;
    public void Start()
    {
        // healthImage.enabled = false;
        // burnImage.enabled = false;
        SetGauge(1.0f);
    }
    public void SetGauge(float targetRate)
    {
        healthImage.DOFillAmount(targetRate, duration).OnComplete(() =>
        {
            burnImage.DOFillAmount(targetRate, duration*0.5f).SetDelay(0.2f);
        });
        currentRate = targetRate;
    }
    public void TakeDamage(float rate)
    {
        SetGauge(currentRate - rate);
    }
    private void Update()
    {
        //パンがpastryBoardの位置に来たら
        if (SimpleLineMover.i == 1)
        {
            healthImage.enabled = true;
            burnImage.enabled = true;
        }
        //パンの位置が中心だったら
        //if (secondPanMover.positionIndex == 0)
        {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(debugDamageRate);
        }
        }
    }

    //はじめはhpゲージ非表示
}
