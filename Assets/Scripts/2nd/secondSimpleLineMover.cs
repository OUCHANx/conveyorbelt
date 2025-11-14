using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class secondSimpleLineMover : MonoBehaviour
{
    [SerializeField] public LineRenderer line;
    [SerializeField] private float speed;
    [SerializeField] private Button addButton;
    [SerializeField] private UnityEvent onEnd;   // 終点到達時のイベント（任意）
    [SerializeField] PanSpawner spawner;
    [SerializeField] private TextMeshProUGUI statusText;
    [SerializeField] private secondSimpleLineMover lineMover;

    public bool isMoving = false;
    public int i; // 目標ポイントのインデックス
    void Start()
    {
        if (line != null)
        {
            transform.position = line.GetPosition(0);
            i = 1; //目標地点は１
        }

        if (addButton != null)
            addButton.onClick.AddListener(() =>
            {
                isMoving = !isMoving;
                // Time.timeScale = isMoving ? 1 : 0;
                // statusText.text = isMoving ? "停止する" : "再開する";
                // if (isMoving)
                // {
                //     PreventRapidClick();
                // }
            });
    }
    void Update()
    {
        // --- 移動処理（オンの時だけ） ---
        if (isMoving && line != null && i < line.positionCount)
        {
            Vector3 target = line.GetPosition(i);
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, target) < 0.005f)
            {
                i++;
                if (i >= line.positionCount) onEnd?.Invoke();//Panが終点に到達したら消える処理、パンにつける
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                var go = hit.transform.gameObject;
                if (go.CompareTag("PanHutuu"))
                {
                    //効果音
                    SEManager.Instance.click();
                    // クリックしたオブジェクトを記録
                    Destroy(go);
                }
            }
        }
    }

    // 生成後に呼び出して初期化する用
    public void Setup(LineRenderer path, float moveSpeed)
    {
        line = path;
        speed = moveSpeed;
        transform.position = line.GetPosition(0);
        i = 1;
        isMoving = true;
    }
    //onoffButtonを連続で押せないようにする
    public void PreventRapidClick()//使いません
    {
        addButton.interactable = false;
        Invoke("EnableButton", 1f); // 1秒後にボタンを再度有効化
    }
    public void EnableButton()
    {
        addButton.interactable = true;
    }
}
