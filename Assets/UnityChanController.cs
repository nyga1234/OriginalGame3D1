using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour
{
    //�A�j���[�V�������邽�߂̃R���|�[�l���g������
    private Animator myAnimator;
    //Unity�������ړ�������R���|�[�l���g������
    private Rigidbody myRigidbody;
    //�O�����̑��x
    private float velocityZ = 8f;
    //�������̑��x
    private float velocityX = 3f;
    //������̑��x
    private float velocityY =12f;
    //���E�̈ړ��ł���͈�
    private float movableRange = 1f;
    //����������������W��
    private float coefficient = 0.99f;
    //�Q�[���I���̔���
    private bool isEnd = false;
    //����������
    private float len = 0;
    //���鑬�x
    private float speed = 5f;
    //�n�ʂ̈ʒu
    private float groundLevel = 0f;
    //���{�^�������̔���i�ǉ��j
    private bool isLButtonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        //Animator�R���|�[�l���g���擾
        this.myAnimator = GetComponent<Animator>();

        //����A�j���[�V�������J�n
        this.myAnimator.SetFloat("Speed", 1);

        //Rigidbody�R���|�[�l���g���擾
        this.myRigidbody = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        //�������������X�V����
        this.len += this.speed * Time.deltaTime;

        //�����������ɉ�����Unity����񂪑����Ȃ�
        if (this.len > 20)
        {
            velocityZ = 12f;
        }
        if (this.len > 40)
        {
            velocityZ = 16f;
        }
        if (this.len > 60)
        {
            velocityZ = 20f;
        }
        if (this.len > 80)
        {
            velocityZ = 24f;
        }
        if (this.len > 100)
        {
            velocityZ = 28f;
        }
        if (this.len > 120)
        {
            velocityZ = 32f;
        }
        if (this.len > 140)
        {
            velocityZ = 36f;
        }
        if (this.len > 160)
        {
            velocityZ = 40f;
        }
        if (this.len > 180)
        {
            velocityZ = 44f;
        }
        if (this.len > 200)
        {
            velocityZ = 48f;
        }
        //�Q�[���I���Ȃ�Unity�����̓�������������
        if (this.isEnd)
        {
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }

        //�������̓��͂ɂ�鑬�x
        float inputVelocityX = 0;
        //������̓��͂ɂ�鑬�x
        float inputVelocityY = 0;

        //Unity��������L�[�܂��̓{�^���ɉ����č��E�Ɉړ�������
        if (Input.GetKey (KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x)
        {
            //�������ւ̑��x����
            inputVelocityX = -this.velocityX;
        }
        else if (Input.GetKey (KeyCode.RightArrow) && this.transform.position.x < this.movableRange)
        {
            //�E�����ւ̑��x����
            inputVelocityX = this.velocityX;
        }

        //�W�����v���Ă��Ȃ����ɃX�y�[�X�������ꂽ��W�����v����
        if(Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f)
        {
            //�W�����v�A�j�����Đ�
            this.myAnimator.SetBool("Jump", true);
            //������ւ̑��x����
            inputVelocityY = this.velocityY;
        }
        else
        {
            //���݂�Y���̑��x����
            inputVelocityY = this.myRigidbody.velocity.y;
        }

        //Jump�X�e�[�g�̏ꍇ��Jump��false���Z�b�g����
        if(this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }
        //Unity�����ɑ��x��^����
        this.myRigidbody.velocity = new Vector3(inputVelocityX, inputVelocityY, velocityZ);

        //���n���Ă��邩�ǂ����𒲂ׂ�
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.myAnimator.SetBool("isGround", isGround);
        //�W�����v��Ԃ̂Ƃ��ɂ̓{�����[����0�ɂ���
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;
    }

    //�g���K�[���[�h�ő��̃I�u�W�F�N�g�ƐڐG�����ꍇ�̏����i�ǉ��j
    void OnTriggerEnter(Collider collider)
    {
        //��Q���ɏՓ˂����ꍇ
        if (collider.gameObject.tag == "CubeTag")
        {
            this.isEnd = true;
            //UIController��GameOver�֐����Ăяo���ĉ�ʏ�ɁuGameOver�v�ƕ\������
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            //gameover��Ԃ̂Ƃ��ɂ̓{�����[����0�ɂ���
            GetComponent<AudioSource>().volume = 0;
        }
    }
}
