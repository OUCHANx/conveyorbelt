using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button zukanButton;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button bagButton;
    [SerializeField] private Button zukanxButton;
    [SerializeField] private GameObject zukanpanel;
    [SerializeField] private Button upgradeContentsxButton;
    [SerializeField] private GameObject upgradeContentspanel;
    [SerializeField] private GameObject line;


    void Start()
    {
        if (zukanButton != null)
            zukanButton.onClick.AddListener(OnZukanButtonClicked);
        if (upgradeButton != null)
            upgradeButton.onClick.AddListener(OnUpgradeButtonClicked);
        if (bagButton != null)
            bagButton.onClick.AddListener(OnBagButtonClicked);
        if (zukanxButton != null)
            zukanxButton.onClick.AddListener(OnZukanXButtonClicked);//図鑑パネルのxボタン
        if (upgradeContentsxButton != null)
            upgradeContentsxButton.onClick.AddListener(OnUpgradeContentsXButtonClicked);//アップグレードパネルのxボタン
    }

    private void OnZukanButtonClicked()
    {
        line.SetActive(true); //透明度を下げたい
        var sr = line.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            Color c = sr.color;
            c.a = 0.5f; // 半透明に
            sr.color = c;
        }
        zukanpanel.SetActive(true);
        Debug.Log("図鑑ボタンがクリックされました");
    }

    private void OnUpgradeButtonClicked()
    {
        upgradeContentspanel.SetActive(true);
        Debug.Log("アップグレードボタンがクリックされました");
    }

    private void OnBagButtonClicked()
    {
        Debug.Log("バッグボタンがクリックされました");
    }

    private void OnZukanXButtonClicked()
    {
        if (zukanpanel.activeSelf)
        {
            zukanpanel.SetActive(false);
        }
    }

        private void OnUpgradeContentsXButtonClicked()
    {
        if (upgradeContentspanel.activeSelf)
        {
            upgradeContentspanel.SetActive(false);
        }

        Debug.Log("Xボタンがクリックされました");
    }

    // Update is called once per frame
    void Update()
    {

    }


}
