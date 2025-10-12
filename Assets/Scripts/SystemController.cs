using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor.Search;

public class SystemController : MonoBehaviour
{
    public static SystemController Instance; // シングルトンでどこからでも呼べるように

    [SerializeField] private TextMeshProUGUI coinText;
    [SerializeField] private Image zukanHutuuImage;
    [SerializeField] private Image zukanBlackImage;
    [SerializeField] private Image zukanPinkImage;

    [SerializeField] public PanData.PanInfo panInfo;
    [SerializeField] private Button speedUpgradeButton;
    [SerializeField] private Button durationUpgradeButton;
    [SerializeField] private PanSpawner spawner;
    [SerializeField] private TextMeshProUGUI durationUpgradeButtonCoinText;
    [SerializeField] private TextMeshProUGUI speedUpgradeButtonCoinText;
    //[SerializeField] private int xamount = 100; //アップグレードに必要なコインの数
    public int coins = 0;//所持金
    //↓全部初期値
    private int durationUpgradeLevel = 1;
    private int durationUpgradeCost = 100;
    private int speedUpgradelevel = 1;
    private int speedUpgradeCost = 100;

    void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        // これはベルトコンベアの速さ
        speedUpgradeButton.onClick.AddListener(() =>
        {
            if (coins >= speedUpgradeCost)
            {
                DecreaseCoinsAndIncreaseSpeed(speedUpgradeCost);
                speedUpgradelevel++;
                speedUpgradeCost *= 5; // 必要コインを5倍に
                speedUpgradeButtonCoinText.text = speedUpgradeCost.ToString() + "円";
                //テキストを用意
                Debug.Log($"レベル{speedUpgradelevel}になりました。次の必要コイン:{speedUpgradeCost}");
            }
        });

        //これは生成間隔
        durationUpgradeButton.onClick.AddListener(() =>
        {
            if (coins >= durationUpgradeCost)
            {
                DecreaseCoinsAndInterval(durationUpgradeCost);
                durationUpgradeLevel++;
                durationUpgradeCost *= 5; // 必要コインを5倍に
                durationUpgradeButtonCoinText.text = durationUpgradeCost.ToString() + "円";
                //テキストを用意
                Debug.Log($"レベル{durationUpgradeLevel}になりました。次の必要コイン:{durationUpgradeCost}");
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
        panInfo.price = coins;
        coins += amount;
        if (coinText != null)
            coinText.text = coins.ToString() + "円";
    }
    //ガチャを引いた時に減少するコインの数
    public void GachaSubstractCoins(int substractcoins)
    {
        coins -= substractcoins;
        if (coinText != null)
        {
            coinText.text = coins.ToString() + "円";
        }
    }
    //----アップグレード機能
    //1.生成時間を減少させる
    //2.ベルトコンベアの速さを上げる

    private void DecreaseCoinsAndInterval(int amount)
    {
        coins -= amount;
        spawner.DecreasedurationX(0.05f);
        if (coinText != null)
            coinText.text = coins.ToString() + "円";
    }

    private void DecreaseCoinsAndIncreaseSpeed(int amount)
    {
        coins -= amount;
        spawner.IncreaseX(1);
        if (coinText != null)
            coinText.text = coins.ToString() + "円";
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


//--------図鑑機能
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
