using UnityEngine;
using System.Collections;

public class HighScore : MonoBehaviour {

	void Start () {
        GetComponent<GUIText>().fontSize = Mathf.RoundToInt(Camera.main.pixelHeight / 17f);
        GetComponent<GUIText>().text = System.String.Concat("BEST SCORE\n", CalculateHighScore(Score.TotalScore).ToString());
	}

    int CalculateHighScore(int score) {
        int PreviousHighScore = PlayerPrefs.GetInt("high_score", 0);
        if(score > PreviousHighScore) {
            PlayerPrefs.SetInt("high_score", score);
            SocialManager.PostToLeaderboard((int)score);
        }
        return PlayerPrefs.GetInt("high_score", 0);
    }
}
