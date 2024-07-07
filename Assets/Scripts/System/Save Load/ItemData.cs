using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData 
{
    public int countItem;
    public int[] id;
    public int[] type;
    public float[] Px;
    public float[] Py;
    public float[] Pz;
    public float[] Qx;
    public float[] Qy;
    public float[] Qz;
    public float[] Qw;

    public ItemData(GameObject gameObject)
    {
        countItem = gameObject.transform.childCount;
        id = new int[countItem];
        type = new int[countItem];
        Px = new float[countItem];
        Py = new float[countItem];
        Pz = new float[countItem];
        Qx = new float[countItem];
        Qy = new float[countItem];
        Qz = new float[countItem];
        Qw = new float[countItem];

        for (int i = 0; i < countItem; i++)
        {
            id[i] = ((int)gameObject.transform.GetChild(i).GetComponent<Item>().item.itemID);
            Px[i] = gameObject.transform.GetChild(i).GetComponent<Item>().originalPosition.x;
            Py[i] = gameObject.transform.GetChild(i).GetComponent<Item>().originalPosition.y;
            Pz[i] = gameObject.transform.GetChild(i).GetComponent<Item>().originalPosition.z;
            Qx[i] = gameObject.transform.GetChild(i).GetComponent<Item>().transform.rotation.x;
            Qy[i] = gameObject.transform.GetChild(i).GetComponent<Item>().transform.rotation.y;
            Qz[i] = gameObject.transform.GetChild(i).GetComponent<Item>().transform.rotation.z;
            Qw[i] = gameObject.transform.GetChild(i).GetComponent<Item>().transform.rotation.w;
        }
        for (int i = countItem - 1; i >= 0; i--)
        {
            gameObject.transform.GetChild(i).GetComponent<Item>().DestroyItem();
        }
    }
}
