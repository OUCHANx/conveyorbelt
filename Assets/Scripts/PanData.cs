using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PanData", menuName = "Game Data/Pan")]
public class PanData : ScriptableObject
{
    public List<PanInfo> pans;
    [System.Serializable]
    public class PanInfo
    {
        public string name;
        public int price;
        public int hp;
        public int exp;
        public int having; //所持数
    }
}
