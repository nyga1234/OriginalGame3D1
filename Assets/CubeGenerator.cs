using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    //�L���[�u��Prefab
    public GameObject cubePrefab;

    //���Ԍv���p�̕ϐ�
    private float delta = 0;

    //�L���[�u�̐����Ԋu
    private float span = 1.0f;

    //�L���[�u�̐����ʒu:z���W
    private float genPosZ = 12;

    //�L���[�u�̐����ʒu�I�t�Z�b�g
    private float offsetZ = 0.5f;
    //�L���[�u�̉������̊Ԋu
    private float spaceZ = 0.4f;

    //�L���[�u���o��X�����͈̔�
    private float posRange = 1f;


    // Start is called before the first frame update
    void Start()
    {
        //���̋������ƂɃA�C�e���𐶐�
        for (int i = 10; i < 10000; i += 30)
        {
            //���[�����ƂɃA�C�e���𐶐�
            for (int j = -1; j <= 1; j++)
            {
                
                    //�L���[�u�𐶐�
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
