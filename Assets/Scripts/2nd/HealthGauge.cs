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

    public bool isGaugeActive;
    private bool hasDepleted;

    public System.Action OnGaugeEmpty;

    private void Start()
    {
        currentRate = 1.0f;
        HideGauge();
    }

    public void ShowGauge(float targetRate)
    {
        isGaugeActive = true;
        hasDepleted = false;
        if (healthImage != null) healthImage.enabled = true;
        if (burnImage != null) burnImage.enabled = true;
        SetGauge(targetRate);
    }

    public void HideGauge()
    {
        isGaugeActive = false;
        if (healthImage != null) healthImage.enabled = false;
        if (burnImage != null) burnImage.enabled = false;
    }

    public void ResetGauge()
    {
        currentRate = 1.0f;
        hasDepleted = false;
        HideGauge();
    }

    public void SetGauge(float targetRate)
    {
        currentRate = Mathf.Clamp01(targetRate);
        if (!isGaugeActive) return;

        healthImage.DOFillAmount(currentRate, duration).OnComplete(() =>
        {
            burnImage.DOFillAmount(currentRate, duration * 0.5f).SetDelay(0.2f).OnComplete(CheckDepleted);
        });
    }

    public void TakeDamage(float rate)
    {
        if (!isGaugeActive) return;
        SetGauge(currentRate - rate);
    }

    private void CheckDepleted()
    {
        if (hasDepleted) return;
        if (currentRate <= 0f)
        {
            hasDepleted = true;
            OnGaugeEmpty?.Invoke();
        }
    }

    private void Update()
    {
        if (!isGaugeActive) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(debugDamageRate);
        }
    }
}
