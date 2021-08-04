using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    //キューブのPrefab
    public GameObject cubePrefab;

    //時間計測用の変数
    private float delta = 0;

    //キューブの生成間隔
    private float span = 1.0f;

    //キューブの生成位置:z座標
    private float genPosZ = 12;

    //キューブの生成位置オフセット
    private float offsetZ = 0.5f;
    //キューブの奥方向の間隔
    private float spaceZ = 0.4f;

    //キューブを出すX方向の範囲
    private float posRange = 1f;


    // Start is called before the first frame update
    void Start()
    {
        //一定の距離ごとにアイテムを生成
        for (int i = 10; i < 10000; i += 30)
        {
            //レーンごとにアイテムを生成
            for (int j = -1; j <= 1; j++)
            {
                
                    //キューブを生成
                    GameObject go = Instantiate(cubePrefab);
                    go.transform.position = new Vector3(posRange * j, go.transform.position.y, i + offsetZ);
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
