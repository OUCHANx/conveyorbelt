using System.Collections;
using TMPro;
using UnityEngine;
public class PanSpawner : MonoBehaviour
{
    [Header("経路設定")]
    [SerializeField] private LineRenderer path;   // ベルトのライン
    [Header("生成設定")]
    [SerializeField] public GameObject panNormalPrefab; // パンのプレハブ
    [SerializeField] public GameObject panBlackPrefab; // 特殊パンのプレハブ
    [SerializeField] public GameObject panPinkPrefab; // 特殊パンのプレハブ
    [SerializeField] private float x = 2;//スピード
    [SerializeField] private float interval = 3f;  // 生成間隔


    [SerializeField, Range(0, 100)] public int normalPercent = 80;
    [SerializeField, Range(0, 100)] public int blackPercent = 15;
    [SerializeField, Range(0, 100)] public int pinkPercent = 5;

    [SerializeField] private SimpleLineMover mover;  // ← SimpleLineMoverを参照しておく
    //[SerializeField] private TextMeshProUGUI coinText;
    private Coroutine spawnRoutine;


    void Start()
    {
        // 最初は何もしない（ボタンが押されて isMoving = true になったら開始）
        // mover の参照がなければ同じオブジェクトから探す
        if (mover == null) mover = GetComponent<SimpleLineMover>();
    }

    void Update()
    {
        // ボタンで isMoving が切り替わるたびに生成ループをON/OFF
        if (mover != null)
        {
            if (mover.isMoving && spawnRoutine == null)
            {
                // ONになったらループ開始
                spawnRoutine = StartCoroutine(SpawnLoop());
            }
            else if (!mover.isMoving && spawnRoutine != null)
            {
                // OFFになったらループ停止
                StopCoroutine(spawnRoutine);
                spawnRoutine = null;
            }
        }
    }

    //public void AddCoin(int amount)
    //{
    //  //  coin += amount;
    //    if (coinText != null)
    //        coinText.text = coin.ToString();
    //}
    GameObject PickPrefabSimple()
    {
        int roll = Random.Range(0, 100); // 0〜99

        if (roll < normalPercent) return panNormalPrefab;
        else if (roll < normalPercent + blackPercent) return panBlackPrefab;
        else return panPinkPrefab; // 残り
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            SpawnOne();
            yield return new WaitForSeconds(interval);
        }
    }
    
    //パン生成スクリプト
        void SpawnOne()
    {
        //if (path == null || panPrefab == null) return;
        // 出現位置（ラインの最初の点）
        Vector3 pos = path.useWorldSpace
            ? path.GetPosition(0)
            : path.transform.TransformPoint(path.GetPosition(0));

        var prefab = PickPrefabSimple();

        // パンを生成
        var go = Instantiate(prefab, pos, Quaternion.identity);

        var lineMover = go.GetComponent<SimpleLineMover>();
        if (lineMover != null)
        {
            lineMover.Setup(path, x);
        }
    }
    //ここに書くべきではない
    public void IncreaseX(int increaseDelta)
    {
        x += increaseDelta;
        if(x >= 2)
        {
            Debug.Log("レベル２になりました");
        }
    }
    public void DecreasedurationX(float dicreaseDuration)
    {
            interval -= dicreaseDuration;
            Debug.Log("パンの生成間隔が短くなりました");
    }
}
