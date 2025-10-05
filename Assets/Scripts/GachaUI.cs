using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cysharp.Threading.Tasks;
using System;
using Unity.VisualScripting;

public class GachaUI : MonoBehaviour
{
    [SerializeField] private GachaManager gacha;
    [SerializeField] private Image resultIcon;
    [SerializeField] private Image frame;
    [SerializeField] private TextMeshProUGUI resultName;
    [SerializeField] private Button pullButton;
    //[SerializeField] private PanData.PanInfo panInfo;


    // OnClickにはこのメソッドを直接割り当ててOK
    public async void OnPullButton()
    {
        if (SystemController.Instance.panInfo.price < 500)
    {
        if (resultName) resultName.text = "コインが足りません！";
        Debug.Log("コインが足りません");
        return;
    }
            // 連打防止（任意）
        if (pullButton) pullButton.interactable = false;

            // 一旦プレースホルダー表示
            if (resultName) resultName.text = "回転中...";
            if (resultIcon) resultIcon.sprite = null;
            // if (frame)
            // {
            //     Color[] colors = { Color.red, Color.blue, Color.green, Color.yellow, Color.magenta };
            //     int index = UnityEngine.Random.Range(0, colors.Length);
            //     frame.color = colors[index];
            // }


            // ★ ここで2秒待つ！
            await UniTask.Delay(TimeSpan.FromSeconds(2));

            // 抽選して結果表示
            ItemData item = gacha.Draw();
            if (item != null)
            {
                frame.color = Color.white;
                resultIcon.sprite = item.itemImage;
                resultIcon.preserveAspect = true;
                resultName.text = $"{item.itemName}";
            }
            else
            {
                if (resultName) resultName.text = "はずれ…";
            }

            // 連打防止解除
            if (pullButton) pullButton.interactable = true;
    }
}
