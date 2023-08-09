using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public int poolNumber;
        public GameObject objectPrefab;
        public int poolSize;
    }

    private static ObjectPooler _instance;
    public static ObjectPooler Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("ObjectPooler is Null");
            }

            return _instance;
        }
    }

    [SerializeField]
    List<Pool> _pools;

    [SerializeField]
    Dictionary<int, Queue<GameObject>> _poolDictionary;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        _poolDictionary = new Dictionary<int, Queue<GameObject>>();

        foreach (Pool pool in _pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.poolSize; i++)
            {
                GameObject obj = Instantiate(pool.objectPrefab);
                obj.SetActive(false);

                objectPool.Enqueue(obj);

                if (pool.poolNumber == 0)
                    obj.transform.SetParent(transform.GetChild(0));
                else if (pool.poolNumber == 1)
                    obj.transform.SetParent(transform.GetChild(1));
            }

            _poolDictionary.Add(pool.poolNumber, objectPool);
        }
    }

    public GameObject SpawnFromPool(int poolNumber)
    {
        if (!_poolDictionary.ContainsKey(poolNumber))
        {
            Debug.LogError("Pool Tag doesn't exist in the Dictionary");
            return null;
        }

        GameObject objectToSpawn = _poolDictionary[poolNumber].Dequeue();

        objectToSpawn.SetActive(true);
        //objectToSpawn.transform.position = spawnPosition;

        _poolDictionary[poolNumber].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
