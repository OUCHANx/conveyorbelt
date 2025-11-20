using UnityEngine;

public class Paninfo : MonoBehaviour
{
    public string panName; // 例: "a" または "b"
    public int hp;         // 初期HP（a=10, b=20など）
    public HealthGauge healthGauge; // Inspectorでセット（子オブジェクトでもOK）

    private void Start()
    {
        // こね台に乗るまではゲージ非表示
        if (healthGauge != null)
            healthGauge.gameObject.SetActive(false);
    }

    // パンがこね台に触れたらHPセット＋表示
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PastryBoard")) // 台にTagを付けておく
        {
            if (healthGauge != null)
            {
                healthGauge.gameObject.SetActive(true);

                // HPを割合(0~1)に換算してゲージに代入
                float rate = (float)hp / 100f;
                healthGauge.SetGauge(rate);
            }
        }
    }
}
