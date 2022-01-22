using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private List<GameObject> objects = new List<GameObject>();

    public void CreatePool(GameObject poolObject)
    {
        GameObject temp = Instantiate(poolObject.gameObject);
        objects.Add(temp);
        temp.transform.SetParent(transform);
        temp.SetActive(false);
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            if (objects[i].gameObject.activeInHierarchy == false)
            {
                return objects[i];
            }
        }
        CreatePool(objects[0]);
        return objects[objects.Count - 1];
    }
}
