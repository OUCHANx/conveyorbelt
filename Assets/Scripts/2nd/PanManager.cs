using System.Collections.Generic;
using System.Security.Cryptography;
using NUnit.Framework;
using UnityEngine;

public class PanManager : MonoBehaviour
{
    [SerializeField] private GameObject panPrefab;
    [SerializeField] private List<GameObject> pans = new List<GameObject>();

    public void CreatePan()
    {
        var canvas = FindFirstObjectByType<Canvas>();
        GameObject newPan = Instantiate(panPrefab, canvas.transform, false);

        //ベルトコンベアから流れてくるようにしたい

        pans.Add(newPan);
    }

    public void DeletePan()
    {
        if (pans.Count > 0)
        {
            GameObject lastPan = pans[pans.Count - 1];
            Destroy(lastPan);
            pans.RemoveAt(pans.Count - 1);
            //pans.Remove(lastPan);でもいい
        }
    }
}
