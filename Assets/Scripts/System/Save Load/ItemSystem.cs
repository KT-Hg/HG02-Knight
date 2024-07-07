using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSystem : MonoBehaviour
{
    public List<GameObject> item = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveItem()
    {
        SaveSystem.SaveItem(gameObject);
        LoadItem();
    }

    public void LoadItem()
    {
        ItemData data = SaveSystem.LoadItem();
        int countItem = gameObject.transform.childCount;
        for (int i = countItem - 1; i >= 0; i--)
        {
            gameObject.transform.GetChild(i).GetComponent<Item>().DestroyItem();
        }
        for (int i = 0; i < data.countItem; i++)
        {
            Vector3 vector3P = new Vector3(data.Px[i], data.Py[i], data.Pz[i]);
            Quaternion vector4Q = new Quaternion(data.Qx[i], data.Qy[i], data.Qz[i], data.Qw[i]);
            Instantiate(item[data.id[i]], vector3P, vector4Q, gameObject.transform);
        }
    }
}
