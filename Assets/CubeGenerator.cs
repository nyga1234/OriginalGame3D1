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
    private float posRangeX = 1f;
    //キューブを出すY方向の範囲
    private float posRangeY = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        //一定の距離ごとにキューブを生成
        for (int i = 10; i < 10000; i += 30)
        {
            //どのレーンにキューブを出すのかをランダムに設定
            int num = Random.Range(-1, 1);
            if (num == -1)
            {
                //真ん中と右にキューブを生成
                for (int j = 0; j <= 1; j++)
                {
                    //縦にキューブを生成
                    for (int k = 1; k <= 3; k++)
                    {
                        //キューブを生成
                        GameObject go = Instantiate(cubePrefab);
                        go.transform.position = new Vector3(posRangeX * j, posRangeY * k, i + offsetZ);
                    }
                }
            }
            if (num == 0)
            {
                //左と右にキューブを生成
                for (int j = -1; j <= 1; j++)
                {
                    //縦にキューブを生成
                    for (int k = 1; k <= 3; k++)
                    {
                        //キューブを生成
                        GameObject go = Instantiate(cubePrefab);
                        go.transform.position = new Vector3(posRangeX * j, posRangeY * k, i + offsetZ);
                    }
                }
            }
            if (num == 1)
            {
                //左と真ん中にキューブを生成
                for (int j = -1; j <= 0; j++)
                {
                    //縦にキューブを生成
                    for (int k = 1; k <= 3; k++)
                    {
                        //キューブを生成
                        GameObject go = Instantiate(cubePrefab);
                        go.transform.position = new Vector3(posRangeX * j, posRangeY * k, i + offsetZ);
                    }
                }
            }
        }

            
       
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
