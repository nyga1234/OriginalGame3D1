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
    private float posRangeX = 1f;
    //�L���[�u���o��Y�����͈̔�
    private float posRangeY = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        //���̋������ƂɃL���[�u�𐶐�
        for (int i = 10; i < 10000; i += 30)
        {
            //�ǂ̃��[���ɃL���[�u���o���̂��������_���ɐݒ�
            int num = Random.Range(-1, 1);
            if (num == -1)
            {
                //�^�񒆂ƉE�ɃL���[�u�𐶐�
                for (int j = 0; j <= 1; j++)
                {
                    //�c�ɃL���[�u�𐶐�
                    for (int k = 1; k <= 3; k++)
                    {
                        //�L���[�u�𐶐�
                        GameObject go = Instantiate(cubePrefab);
                        go.transform.position = new Vector3(posRangeX * j, posRangeY * k, i + offsetZ);
                    }
                }
            }
            if (num == 0)
            {
                //���ƉE�ɃL���[�u�𐶐�
                for (int j = -1; j <= 1; j++)
                {
                    //�c�ɃL���[�u�𐶐�
                    for (int k = 1; k <= 3; k++)
                    {
                        //�L���[�u�𐶐�
                        GameObject go = Instantiate(cubePrefab);
                        go.transform.position = new Vector3(posRangeX * j, posRangeY * k, i + offsetZ);
                    }
                }
            }
            if (num == 1)
            {
                //���Ɛ^�񒆂ɃL���[�u�𐶐�
                for (int j = -1; j <= 0; j++)
                {
                    //�c�ɃL���[�u�𐶐�
                    for (int k = 1; k <= 3; k++)
                    {
                        //�L���[�u�𐶐�
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
