using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SystemController : MonoBehaviour
{
    public static SystemController Instance; // シングルトンでどこからでも呼べるように

    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private Image zukanHutuuImage;
    [SerializeField] private Image zukanBlackImage;
    [SerializeField] private Image zukanPinkImage;

    [SerializeField] private PanData.PanInfo panInfo;
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
        UpdateHutuuImage();
        UpdateBlackImage();
        UpdatePinkImage();
    }

    public void AddCoins(int amount)
    {
        panInfo.price += amount;
        if (coinText != null)
            coinText.text = panInfo.price.ToString() + "円";
    }
    public void SubtractCoins(int xamount)
    {
        panInfo.price -= xamount;
        spawner.DecreasedurationX(0.05f);
        if (coinText != null)
            coinText.text = panInfo.price.ToString() + "円";
    }
    public void SubstractCoins1(int xamount)
    {
        panInfo.price -= xamount;
        spawner.IncreaseX(1);
        if (coinText != null)
            coinText.text = panInfo.price.ToString() + "円";
    }

    public void AddHutuuhaving(int amountHutuu)
    {
        panInfo.havingHutuu += amountHutuu;
    }
    public void AddBlackhaving(int amountBlack)
    {
        panInfo.havingBlack += amountBlack;
    }
    public void AddPinkhaving(int amountPink)
    {
        panInfo.havingPink += amountPink;
    }



    private void UpdateHutuuImage()
    {
        Color h = zukanHutuuImage.color;
        if (panInfo.havingHutuu == 0)
        {
            // 半透明にする
            h.a = 0.3f;
        }
        else if (panInfo.havingHutuu >= 1)
        {
            // 通常（不透明）に戻す
            h.a = 1f;
        }
        zukanHutuuImage.color = h;
    }

    private void UpdateBlackImage()
    {
        Color b = zukanBlackImage.color;
        if (panInfo.havingBlack == 0)
        {
            // 半透明にする
            b.a = 0.3f;
        }
        else if (panInfo.havingBlack >= 1)
        {
            // 通常（不透明）に戻す
            b.a = 1f;
        }
        zukanBlackImage.color = b;
    }

    private void UpdatePinkImage()
    {
        Color p = zukanPinkImage.color;
        if (panInfo.havingPink == 0)
        {
            // 半透明にする
            p.a = 0.3f;
        }
        else if (panInfo.havingPink >= 1)
        {
            // 通常（不透明）に戻す
            p.a = 1f;
        }
        zukanPinkImage.color = p;
    }
}
