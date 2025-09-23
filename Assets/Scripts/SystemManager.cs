using UnityEngine;
using TMPro;
using UnityEngine.UI;   // TextMeshPro を使う場合

public class SystemController : MonoBehaviour
{
    public static SystemController Instance; // シングルトンでどこからでも呼べるように

    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private SpriteRenderer zukanImage; // InspectorでzukanpanelのImageをセット
    [SerializeField] private PanData.PanInfo panInfo; // Inspectorで割り
    [SerializeField] private Button conveyorUpgradeButton;
    [SerializeField] private Button durationUpgradeButton;
    [SerializeField] private PanSpawner spawner;
    [SerializeField] private int xamount = 100;
    //private int coins = 0;
    void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Debug.Log("githubに公開してみる");
        // これはベルトコンベアの速さ
        conveyorUpgradeButton.onClick.AddListener(() =>
        {
            if (panInfo.price >= 100)
            {
                SubstractCoins1(xamount);
            }
        });

        //これは生成間隔
        durationUpgradeButton.onClick.AddListener(() =>
        {
            if (panInfo.price >= 100)
            {
                SubtractCoins(xamount);
            }
        });
    }

    private void Update()
    {
        //UpdateImage();
        if (panInfo.having >= 1)
        {
            Color c = zukanImage.color;
            if (panInfo.having == 0)
            {
                // 半透明にする
                c.a = 0.3f;
            }
            else if (panInfo.having >= 1)
            {
                // 通常（不透明）に戻す
                c.a = 1f;
            }
            zukanImage.color = c;
        }
        else
        {
            Color c = zukanImage.color;
            c.a = 0.3f;
            zukanImage.color = c;
        }



    }

    public void AddCoins(int amount)
    {
        panInfo.price += amount;
        if (coinText != null)
            coinText.text = panInfo.price.ToString();
    }
    public void SubtractCoins(int xamount)
    {
        panInfo.price -= xamount;
        spawner.DecreasedurationX(0.05f);
        if (coinText != null)
            coinText.text = panInfo.price.ToString();
    }
    public void SubstractCoins1(int xamount)
    {
        panInfo.price -= xamount;
        spawner.IncreaseX(1);
        if (coinText != null)
            coinText.text = panInfo.price.ToString();
    }

    public void Addhaving(int amount)
    {
        panInfo.having += amount;
    }


    // private void UpdateImage()
    // {
    //     if (zukanImage == null) return;

    //     Color c = zukanImage.color;
    //     if (panInfo.having == 0)
    //     {
    //         // 半透明にする
    //         c.a = 0.3f;
    //     }
    //     else if (panInfo.having >= 1)
    //     {
    //         // 通常（不透明）に戻す
    //         c.a = 1f;
    //     }
    //     zukanImage.color = c;
    // }


}
