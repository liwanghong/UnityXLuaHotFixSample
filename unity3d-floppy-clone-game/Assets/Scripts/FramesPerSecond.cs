using UnityEngine;
using System.Collections;

public class FramesPerSecond : MonoBehaviour {

    public float updateInterval = 0.5F;
    private float totalFPS = 0;
    private int totalFrames = 0;
    private float timeUntilUpdate;

    void Start () {
        GetComponent<GUIText>().fontSize = Mathf.RoundToInt(Camera.main.pixelHeight / 30f);
        GetComponent<GUIText>().alignment = TextAlignment.Right;
        GetComponent<GUIText>().anchor = TextAnchor.UpperRight;
        GetComponent<GUIText>().text = "0 FPS";
        timeUntilUpdate = updateInterval;
    }
    
    void Update () {
        timeUntilUpdate -= Time.deltaTime;
        totalFPS += Time.timeScale / Time.deltaTime;
        ++totalFrames;
        if(timeUntilUpdate <= 0.0) {
            float fps = totalFPS / totalFrames;
            GetComponent<GUIText>().text = System.String.Format("{0:F2} FPS", fps);
            timeUntilUpdate = updateInterval;
            totalFPS = 0.0F;
            totalFrames = 0;
        }
    }
}