using UnityEngine;
using UnityEngine.UIElements;

public class Paninfo : MonoBehaviour
{
    public string panName;  // パンの名前
    public int hp;         // 初期HP（a=10, b=20など）
    [SerializeField] private HealthGauge healthGauge; // Inspectorでセット（子オブジェクトでもOK）
    private void Start()
    {
        // こね台に乗るまではゲージ非表示
        if (healthGauge != null)
            healthGauge.HideGauge();
    }

    // パンがこね台に触れたらHPセット＋表示
    private void OnTriggerEnter2D(Collider2D other)
    //ontriggerenter2dの発動条件調べる
    {
        if (other.CompareTag("PastryBoard")) // 台にTagを付けておく
        {
            if (healthGauge != null)
            {
                // HPを割合(0~1)に換算してゲージに代入
                float rate = (float)hp / 100f;
                healthGauge.ShowGauge(rate);
            }
        }
    }
}
