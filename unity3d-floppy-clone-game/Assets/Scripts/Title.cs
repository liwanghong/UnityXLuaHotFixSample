using UnityEngine;
using System.Collections;

public class Title : MonoBehaviour {

	void Start () {
        GetComponent<GUIText>().fontSize = Mathf.RoundToInt(Camera.main.pixelHeight / 14f);
	}
	
}
