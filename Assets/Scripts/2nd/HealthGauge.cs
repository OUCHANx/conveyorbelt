using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class HealthGauge : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    [SerializeField] private Image burnImage;
    public float duration = 0.5f; //０.５秒でヘルスが減るアニメーションを実行
    public float debugDamageRate = 0.2f;
    public float currentRate = 1.0f;
    public void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(debugDamageRate);
        }
    }
}
