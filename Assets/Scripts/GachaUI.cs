using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GachaUI : MonoBehaviour
{
    [SerializeField] private GachaManager gacha;
    [SerializeField] private Image resultIcon;
    [SerializeField] private TextMeshProUGUI resultName;

    public void OnPullButton()
    {
        var item = gacha.Draw();
        if (item == null) return;

        resultIcon.sprite = item.itemImage;
        resultIcon.preserveAspect = true;

        if (resultName) resultName.text = $"{item.itemName} (R{item.rarity})";
    }
}
