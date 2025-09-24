using UnityEngine;

public class Pan : MonoBehaviour
{
    [SerializeField] private PanData.PanInfo panInfo;
    void OnMouseDown()
    {
        string objName = gameObject.name;
        if (objName.Contains("1PanNormal"))
        {
            SystemController.Instance.AddHutuuhaving(1);
        }
        if (objName.Contains("2PanBlack"))
        {
            SystemController.Instance.AddBlackhaving(1);
        }
        if (objName.Contains("3PanPink"))
        {
            SystemController.Instance.AddPinkhaving(1);
        }
        {
            // 消去と同時にコイン加算
            SystemController.Instance.AddCoins(panInfo.price);
            //SystemController.Instance.AddHutuuhaving(1);
            //SystemController.Instance.Addhaving(panInfo.havingBlack);
            //SystemController.Instance.Addhaving(panInfo.havingPink);

            //Destroy(gameObject);
        }
    }
}
