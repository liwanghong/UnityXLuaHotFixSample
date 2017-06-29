using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	void Start () {
        GetComponent<GUIText>().fontSize = Mathf.RoundToInt(Camera.main.pixelHeight / 12f);
	}

}
