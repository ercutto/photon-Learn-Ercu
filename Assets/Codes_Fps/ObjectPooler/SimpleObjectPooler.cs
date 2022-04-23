using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectPooler : MonoBehaviour
{
    public static SimpleObjectPooler instance;
    private List<GameObject> pooledObjects = new List<GameObject>();
    public int amountToPool;
    [SerializeField] private GameObject bulletPrefab;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(bulletPrefab);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

    }
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {

    }

}
