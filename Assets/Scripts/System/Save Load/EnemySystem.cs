using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    public List<Enemy.idEnemy> id;
    public List<Vector3> positions;
    public List<Quaternion> quaternions;
    public List<GameObject> enemy = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        id = new List<Enemy.idEnemy>();
        /*SaveEnemy();*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SaveEnemy()
    {
        SaveSystem.SaveEnemy(gameObject);
        LoadEnemy();
    }

    public void LoadEnemy()
    {
        EnemyData data = SaveSystem.LoadEnemy();
        int countEnemy = gameObject.transform.childCount;
        for (int i = countEnemy - 1; i >= 0; i--)
        {
            gameObject.transform.GetChild(i).GetComponent<Enemy>().destroy();
        }
        for (int i = 0; i < data.countEnemy; i++)
        {
            Vector3 vector3P = new Vector3(data.Px[i], data.Py[i], data.Pz[i]);
            Quaternion vector4Q = new Quaternion(data.Qx[i], data.Qy[i], data.Qz[i],data.Qw[i]);
            Instantiate(enemy[data.id[i]], vector3P, vector4Q, gameObject.transform);
        }
    }
}
