using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public PoolName poolName;
        public GameObject prefab;
        public int size;
    }

    public enum PoolName
    {
        ButtonClickSound
    }

    public List<Pool> pools;
    public Dictionary<PoolName, Queue<GameObject>> poolDictionary;

    #region static instance
    static PoolManager _instance;
    public static PoolManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PoolManager>();
            }
            return _instance;
        }
    }
    #endregion

    void Awake()
    {
        _instance = this;
        poolDictionary = new Dictionary<PoolName, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.poolName, objectPool);
        }
    }

    public GameObject SpawnFromPool(PoolName poolName, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(poolName)) return null;

        GameObject objectToSpawn = poolDictionary[poolName].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();

        if (pooledObj != null)
            pooledObj.OnObjectSpawn();

        poolDictionary[poolName].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
