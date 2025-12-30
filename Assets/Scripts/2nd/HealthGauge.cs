using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.Events;

public class HealthGauge : MonoBehaviour
{
    [SerializeField] private Image healthImage;
    [SerializeField] private Image burnImage;
    public float duration = 0.5f; //０.５秒でヘルスが減るアニメーションを実行
    public float debugDamageRate = 0.2f;
    [SerializeField] private bool enableDebugKey = true;
    [SerializeField] private KeyCode debugKey = KeyCode.Space;
    public float currentRate = 1.0f;

    public bool isGaugeActive;
    private bool hasDepleted;

    public UnityEvent OnGaugeEmpty;

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

    // デバッグ用ダメージ（ボタンやイベントから呼べる）
    public void DebugDamage()
    {
        TakeDamage(debugDamageRate);
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
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hits = Physics2D.RaycastAll(ray.origin, ray.direction);
            foreach (var hit in hits) // 前面の別コライダーがあってもPastryBoard優先で判定
            {
                if (hit.collider != null && hit.collider.CompareTag("PastryBoard"))
                {
                    DebugDamage();
                    break;
                }
            }
        }

        if (enableDebugKey && Input.GetKeyDown(debugKey))
        {
            DebugDamage();
        }
    }
}
