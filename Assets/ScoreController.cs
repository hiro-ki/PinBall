using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	private GameObject scoreText;
	private int score = 0;

	// Use this for initialization
	void Start () {
		this.scoreText = GameObject.Find ("ScoreText");
	}
		
void OnCollisionEnter(Collision other) {

	    if (other.gameObject.tag == "SmallStarTag") {
			this.score += 5;
		} else if (other.gameObject.tag == "LargeStarTag"){
			this.score += 10;
		} else if (other.gameObject.tag == "SmallCloudTag"){
			this.score += 25;
		} else if (other.gameObject.tag == "LargeCloudTag"){
			this.score += 20;
	    }
		this.scoreText.GetComponent<Text> ().text = "Score " + this.score + "pt";

}

}