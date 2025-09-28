using UnityEngine;
using UnityEngine.UI;

public class ScrollViewButtonManager : MonoBehaviour
{

    [SerializeField] Button PanHutuuButton;
    void Start()
    {
        if (PanHutuuButton != null)
            PanHutuuButton.onClick.AddListener(PanHutuudetails);
    }



    void Update()
    {

    }
    private void PanHutuudetails()
    {
        Debug.Log("お試し");
    }
}
