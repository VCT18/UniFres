using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;
    public GameObject objectPrefab;
    public int poolSize = 10;
    private List<GameObject> pool = new List<GameObject>();
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }
    public GameObject GetObject()
    {
        foreach (GameObject obj in pool)
        {
            if(obj.activeSelf == false)
            {
                return obj;
            }
        }
        
        GameObject newObj = Instantiate(objectPrefab);
        pool.Add(newObj);
        return newObj;
    }
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
