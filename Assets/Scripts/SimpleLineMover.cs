using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
//Hello Unity 9/19
using Unity;


public class SimpleLineMover : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private float speed;
    [SerializeField] private Button onoffButton;
    [SerializeField] private AudioClip destroySound;
    [SerializeField] private UnityEvent onEnd;   // 終点到達時のイベント（任意）
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] PanSpawner spawner;

    public bool isMoving = false;
    private int i; // 目標ポイントのインデックス
    private GameObject clickedGameObject;
    SimpleLineMover lineMover;
    void Start()
    {
        if (line != null)
        {
            transform.position = line.GetPosition(0);
            i = 1;
        }

        if (onoffButton != null)
            onoffButton.onClick.AddListener(() =>
            {
                isMoving = !isMoving;
                Time.timeScale = isMoving ? 1 : 0;
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
        // --- クリック処理（オン/オフ関係なく常に反応） ---
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                var go = hit.transform.gameObject;
                if (go.CompareTag("PanHutuu"))
                {
                    if (destroySound != null && sfxSource != null)
                    {
                        sfxSource.PlayOneShot(destroySound);
                    }
                    //if (go.name.Contains("Normal"))
                    //{
                    // spawner.AddCoin(10);
                    //}
                    //else if (go.name.Contains("Black"))
                    //{
                    //  spawner.AddCoin(50);
                    //}
                    //else if (go.name.Contains("Pink"))
                    //{
                    //  spawner.AddCoin(100);
                    //}
                    // クリックしたオブジェクトを記録
                    Destroy(go);
                    clickedGameObject = go;
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
}
