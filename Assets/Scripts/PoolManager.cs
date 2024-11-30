using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    List<GameObject>[] pools;
    // Start is called before the first frame update
    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        for (int i = 0; i < pools.Length; i++) {
            pools[i] = new List<GameObject>();
        }
        Debug.Log(pools.Length);
    }

    public GameObject Get(int i) 
    {
        GameObject select = null;
        foreach (GameObject item in pools[i]) {
            if (!item.activeSelf) {
                select = item;
                select.SetActive(true);
                break;
            }
        }

        if (!select) {
            //If we keep using instantiate and destroy will cause memory problem.
            select = Instantiate(prefabs[i],transform);
            pools[i].Add(select);
        }

        return select;
    }
}
