using UnityEngine;

public class Pan : MonoBehaviour
{
    [SerializeField] private PanData.PanInfo panInfo; // Inspectorで割り当てる
    void OnMouseDown()
    {
        if (panInfo != null)
        {
            // 消去と同時にコイン加算
            SystemController.Instance.AddCoins(panInfo.price);
            SystemController.Instance.Addhaving(panInfo.having);
            //Destroy(gameObject);
        }
    }
}
