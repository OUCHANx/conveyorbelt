using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button zukanButton;
    [SerializeField] private Button upgradeButton;
    [SerializeField] private Button shukkaButton;
    [SerializeField] private Button bagButton;


    [SerializeField] private Button zukanxButton;
    [SerializeField] private GameObject zukanpanel;


    [SerializeField] private Button upgradeContentsxButton;
    [SerializeField] private GameObject upgradeContentspanel;

    [SerializeField] private Button shukkaxButton;
    [SerializeField] private GameObject shukkapanel;


    [SerializeField] private GameObject line;

    // [SerializeField] private
    // [SerializeField]
    // [SerializeField]
    // //図鑑にあるパンが押されるとそのパンの詳細が表示されるようにしたい。


    void Start()
    {
        if (zukanButton != null)
            zukanButton.onClick.AddListener(OnZukanButtonClicked);
        if (upgradeButton != null)
            upgradeButton.onClick.AddListener(OnUpgradeButtonClicked);
        if (shukkaButton != null)
            shukkaButton.onClick.AddListener(OnshukkaButtonClicked);
        if (bagButton != null)
            bagButton.onClick.AddListener(OnBagButtonClicked);


        //----バツボタン押したら
        if (zukanxButton != null)
            zukanxButton.onClick.AddListener(OnZukanXButtonClicked);//図鑑パネルのxボタン
        if (upgradeContentsxButton != null)
            upgradeContentsxButton.onClick.AddListener(OnUpgradeContentsXButtonClicked);//アップグレードパネルのxボタン
        if (shukkaxButton != null)
            shukkaxButton.onClick.AddListener(OnshukkaButtonXClicked);
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
    private void OnshukkaButtonClicked()
    {
        shukkapanel.SetActive(true);
        Debug.Log("出荷ボタン押された");
    }


    private void OnBagButtonClicked()
    {
        Debug.Log("バッグボタンがクリックされました");
    }
//------------------↓↓バツボタン押したら↓↓--------------------//
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

    private void OnshukkaButtonXClicked()
    {
        if (shukkapanel.activeSelf)
        {
            shukkapanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}
