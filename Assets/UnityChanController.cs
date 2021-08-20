using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる
    private Animator myAnimator;
    //Unityちゃんを移動させるコンポーネントを入れる
    private Rigidbody myRigidbody;
    //前方向の速度
    private float velocityZ = 8f;
    //横方向の速度
    private float velocityX = 3f;
    //上方向の速度
    private float velocityY =12f;
    //左右の移動できる範囲
    private float movableRange = 1f;
    //動きを減速させる係数
    private float coefficient = 0.99f;
    //ゲーム終了の判定
    private bool isEnd = false;
    //走った距離
    private float len = 0;
    //走る速度
    private float speed = 5f;
    //地面の位置
    private float groundLevel = 0f;
    //左ボタン押下の判定（追加）
    private bool isLButtonDown = false;

    // Start is called before the first frame update
    void Start()
    {
        //Animatorコンポーネントを取得
        this.myAnimator = GetComponent<Animator>();

        //走るアニメーションを開始
        this.myAnimator.SetFloat("Speed", 1);

        //Rigidbodyコンポーネントを取得
        this.myRigidbody = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        //走った距離を更新する
        this.len += this.speed * Time.deltaTime;

        //走った距離に応じてUnityちゃんが速くなる
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
        //ゲーム終了ならUnityちゃんの動きを減衰する
        if (this.isEnd)
        {
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;
        }

        //横方向の入力による速度
        float inputVelocityX = 0;
        //上方向の入力による速度
        float inputVelocityY = 0;

        //Unityちゃんを矢印キーまたはボタンに応じて左右に移動させる
        if (Input.GetKey (KeyCode.LeftArrow) && -this.movableRange < this.transform.position.x)
        {
            //左方向への速度を代入
            inputVelocityX = -this.velocityX;
        }
        else if (Input.GetKey (KeyCode.RightArrow) && this.transform.position.x < this.movableRange)
        {
            //右方向への速度を代入
            inputVelocityX = this.velocityX;
        }

        //ジャンプしていない時にスペースが押されたらジャンプする
        if(Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f)
        {
            //ジャンプアニメを再生
            this.myAnimator.SetBool("Jump", true);
            //上方向への速度を代入
            inputVelocityY = this.velocityY;
        }
        else
        {
            //現在のY軸の速度を代入
            inputVelocityY = this.myRigidbody.velocity.y;
        }

        //Jumpステートの場合はJumpにfalseをセットする
        if(this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }
        //Unityちゃんに速度を与える
        this.myRigidbody.velocity = new Vector3(inputVelocityX, inputVelocityY, velocityZ);

        //着地しているかどうかを調べる
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.myAnimator.SetBool("isGround", isGround);
        //ジャンプ状態のときにはボリュームを0にする
        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;
    }

    //トリガーモードで他のオブジェクトと接触した場合の処理（追加）
    void OnTriggerEnter(Collider collider)
    {
        //障害物に衝突した場合
        if (collider.gameObject.tag == "CubeTag")
        {
            this.isEnd = true;
            //UIControllerのGameOver関数を呼び出して画面上に「GameOver」と表示する
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            //gameover状態のときにはボリュームを0にする
            GetComponent<AudioSource>().volume = 0;
        }
    }
}
