using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    // スコア変数
    private int score = 0;
    //ゲームオーバを表示するテキスト
    private GameObject gamescoreText;

    // Use this for initialization
    void Start ()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン中のGameScoreTextオブジェクトを取得
        this.gamescoreText = GameObject.Find("GameScoreText");
    }



    // Update is called once per frame
    void Update ()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text> ().text = "Game Over";
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "LargeStarTag") {
            this.score += 5;
            Debug.Log("LargeStarTag Hit");
            //GamescoreTextにスコアを表示
            this.gamescoreText.GetComponent<Text>().text = "Score:" + this.score;
        }

        if (other.gameObject.tag == "SmallStarTag") {
            this.score += 1;
            Debug.Log("SmallStarTag Hit");
            //GamescoreTextにスコアを表示
            this.gamescoreText.GetComponent<Text>().text = "Score:" + this.score;
        }

        if (other.gameObject.tag == "LargeCloudTag") {
            this.score += 20;
            Debug.Log("LargeCloudTag Hit");
            //GamescoreTextにスコアを表示
            this.gamescoreText.GetComponent<Text>().text = "Score:" + this.score;
        }

        if (other.gameObject.tag == "SmallCloudTag") {
            this.score += 10;
            Debug.Log("SmallCloudTag Hit");
            //GamescoreTextにスコアを表示
            this.gamescoreText.GetComponent<Text>().text = "Score:" + this.score;
        }
    }
}