using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PanData", menuName = "Game Data/Pan")]
public class PanData : ScriptableObject
{
    public List<PanInfo> pans;

    [System.Serializable]
    public class PanInfo
    {
        public string name;         // 名前
        //public GameObject prefab;   // プレハブ
        public int price;           // 値段
        public int havingHutuu;
        public int havingBlack;
        public int havingPink;
    }
}
