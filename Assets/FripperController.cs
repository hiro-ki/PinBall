using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour {
	//HingeJointコンポーネントを入れる
	private HingeJoint myHingeJoynt;
	//初期の傾き
	private float defaultAngle = 20f;
	//弾いた時の傾き
	private float flickAngle = -20f;
	private float center = Screen.width / 2;


	// Use this for initialization
	void Start () {
		//HingeJointコンポーンネントを取得
		this.myHingeJoynt = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);


	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < Input.touchCount; i++) {

			Touch touch = Input.touches [i];
			float touchPosition = touch.position.x;

			//左キーを押した時左フリッパーを動かす
			if (touchPosition < center && tag == "LeftFripperTag") {
				if (touch.phase == TouchPhase.Began) {
					SetAngle (this.flickAngle);
				}
				if (touch.phase == TouchPhase.Ended) {
					SetAngle (this.defaultAngle);
				}
			}

			//右キーを押した時右フリッパーを動かす
			if (touchPosition > center && tag == "RightFripperTag") {
				if (touch.phase == TouchPhase.Began) {
					SetAngle (this.flickAngle);
				}
				if (touch.phase == TouchPhase.Ended) {
					SetAngle (this.defaultAngle);
				}
			}
		}
	}

	//フリッパーの傾きを設定
	public void SetAngle(float angle) {
		JointSpring jointSpr = this.myHingeJoynt.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoynt.spring = jointSpr;
	}
}
