using System.Collections;
using TMPro;
using UnityEngine;
using System.Collections.Generic;
public class secondPanSpawner : MonoBehaviour
{
    [Header("経路設定")]
    [SerializeField] private LineRenderer path;   // ベルトのライン
    [Header("生成設定")]
    [SerializeField] public GameObject panNormalPrefab;
    [SerializeField] public GameObject panBlackPrefab;
    [SerializeField] public GameObject panPinkPrefab;
    [SerializeField] private float x = 2;//スピード
    [SerializeField] private float interval = 3f;  // 生成間隔


    [SerializeField, Range(0, 100)] public int normalPercent = 80;
    [SerializeField, Range(0, 100)] public int blackPercent = 15;
    [SerializeField, Range(0, 100)] public int pinkPercent = 5;

    [SerializeField] private secondSimpleLineMover mover;  // ← SimpleLineMoverを参照しておく
    // private Coroutine spawnRoutine;
    [SerializeField] private Transform pastryBoard;
    private List<GameObject> spawnedPans = new List<GameObject>(); // 生成済みパンを管理

    void Start()
    {
        // 最初は何もしない（ボタンが押されて isMoving = true になったら開始）
        // mover の参照がなければ同じオブジェクトから探す
        if (mover == null) mover = GetComponent<secondSimpleLineMover>();
    }

    void Update()
    {
        // // ボタンで isMoving が切り替わるたびに生成ループをON/OFF
        // if (mover != null)
        // {
        //     if (mover.isMoving && spawnRoutine == null)
        //     {
        //         // // ONになったらループ開始
        //         // spawnRoutine = StartCoroutine(SpawnLoop());
        //     }
        //     else if (!mover.isMoving && spawnRoutine != null)
        //     {
        //         // OFFになったらループ停止
        //         StopCoroutine(spawnRoutine);
        //         spawnRoutine = null;
        //     }
        // }
        // if (secondSimpleLineMover.i == 1 && mover.isMoving)
        // {
        //
        // }
        // else
        // {
        //     return;
        // }
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

    // IEnumerator SpawnLoop()
    // {
    //     while (true)
    //     {
    //         SpawnOne();
    //         yield return new WaitForSeconds(interval);
    //     }
    // }
    //パン生成スクリプト
    void SpawnOne()
    {
        Vector3 pos = path.useWorldSpace
            ? path.GetPosition(0)
            : path.transform.TransformPoint(path.GetPosition(0));

        var prefab = PickPrefabSimple();

        // パンを生成
        var go = Instantiate(prefab, pos, Quaternion.identity);

        var lineMover = go.GetComponent<secondSimpleLineMover>();
        if (lineMover != null)
        {
            lineMover.Setup(path, x);
        }
        spawnedPans.Add(go);
    }
    //ここに書くべきではない
    public void IncreaseX(int increaseDelta)
    {
        x += increaseDelta;
        if (x >= 2)
        {
            Debug.Log("レベル２になりました");
        }
    }
    public void DecreasedurationX(float dicreaseDuration)
    {
        interval -= dicreaseDuration;
        Debug.Log("パンの生成間隔が短くなりました");
    }

    public void createPan()
    {
        if (spawnedPans.Count > 0)
        {
            // 既にパンが存在する場合は新しいパンを生成しない
            Debug.Log("パンはもうすでに生成されています");
            return;
        }
        SpawnOne();
    }

    public void deletePan()
    {
        if (spawnedPans.Count > 0)
        {
            GameObject panToDelete = spawnedPans[spawnedPans.Count - 1];

            var lineMover = panToDelete.GetComponent<secondSimpleLineMover>();
            if (lineMover != null && lineMover.i >= lineMover.line.positionCount)
            {
                spawnedPans.RemoveAt(spawnedPans.Count - 1);
                Destroy(panToDelete);
                Debug.Log("最終地点のパンを削除しました");
            }
            else
            {
                Debug.Log("パンはまだ最終地点に到達していません");
            }
        }
    }

    // public void addToPastryBoard()
    // {
    //     GameObject lastPan = spawnedPans[spawnedPans.Count - 1];
    //     var mover = lastPan.GetComponent<secondSimpleLineMover>();
    //     if (mover != null && mover.i >= mover.line.positionCount)
    //     {
    //         mover.enabled = false; // linerendererからはずす

    //         Vector3 center = pastryBoard.position;
    //         lastPan.transform.position = center;
    //     }
    // }
    public void addToPastryBoard()
{
    GameObject lastPan = spawnedPans[spawnedPans.Count - 1];
    var mover = lastPan.GetComponent<secondSimpleLineMover>();

    if (mover != null && mover.i >= mover.line.positionCount)
    {
        mover.enabled = false; // LineRendererから外す

        Vector3 center = pastryBoard.position;
        StartCoroutine(MoveToPosition(lastPan, center, 1f)); // 1秒で移動
    }
}

IEnumerator MoveToPosition(GameObject obj, Vector3 target, float duration)
{
    Vector3 start = obj.transform.position;
    float time = 0f;

    while (time < duration)
    {
        time += Time.deltaTime;
        float t = time / duration;
        obj.transform.position = Vector3.Lerp(start, target, t);
        yield return null;
    }

    obj.transform.position = target; // 最終位置を保証
}

}
