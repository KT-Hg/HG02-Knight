using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{ 
    public int countEnemy;
    public int[] id;
    public float[] Px;
    public float[] Py;
    public float[] Pz;
    public float[] Qx;
    public float[] Qy;
    public float[] Qz;
    public float[] Qw;


    public EnemyData(GameObject gameObject)
    {
        countEnemy = gameObject.transform.childCount;
        id = new int[countEnemy];
        Px = new float[countEnemy];
        Py = new float[countEnemy];
        Pz = new float[countEnemy];
        Qx = new float[countEnemy];
        Qy = new float[countEnemy];
        Qz = new float[countEnemy];
        Qw = new float[countEnemy];

        for (int i = 0; i < countEnemy; i++)
        {
            id[i] = ((int)gameObject.transform.GetChild(i).GetComponent<Enemy>().id);
            Px[i] = gameObject.transform.GetChild(i).GetComponent<Enemy>().originalPosition.x;
            Py[i] = gameObject.transform.GetChild(i).GetComponent<Enemy>().originalPosition.y;
            Pz[i] = gameObject.transform.GetChild(i).GetComponent<Enemy>().originalPosition.z;
            Qx[i] = gameObject.transform.GetChild(i).GetComponent<Enemy>().transform.rotation.x;
            Qy[i] = gameObject.transform.GetChild(i).GetComponent<Enemy>().transform.rotation.y;
            Qz[i] = gameObject.transform.GetChild(i).GetComponent<Enemy>().transform.rotation.z;
            Qw[i] = gameObject.transform.GetChild(i).GetComponent<Enemy>().transform.rotation.w;
        }
        for (int i = countEnemy - 1; i >= 0; i--) 
        {
            gameObject.transform.GetChild(i).GetComponent<Enemy>().destroy();
        }
    }
}
