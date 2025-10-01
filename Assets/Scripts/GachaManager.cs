using UnityEngine;

public class GachaManager : MonoBehaviour
{
    [SerializeField] private ItemData[] items; // Inspector に 001〜010 を入れる

    // 重み付きランダム
    // public ItemData Draw()
    // {
    //     if (items == null || items.Length == 0) return null;

    //     int total = 0;
    //     foreach (var it in items) total += Mathf.Max(0, it.rarity);
    //     if (total <= 0) return items[Random.Range(0, items.Length)];

    //     int r = Random.Range(0, total);
    //     foreach (var it in items)
    //     {
    //         r -= Mathf.Max(0, it.rarity);
    //         if (r < 0) return it;
    //     }
    //     return items[items.Length - 1];
    // }


    public ItemData Draw()
{
    // itemsがnullまたは空なら抽選できないのでnullを返す
    if (items == null || items.Length == 0) return null;

    // itemsの中からランダムに1つ選んで返す
    return items[Random.Range(0, items.Length)];
}
}
