using TMPro;
using UnityEngine;

public class FpsDisplay : MonoBehaviour
{
    public TextMeshProUGUI FpsText;

    private float pollingTime = 3f;
    private float time;
    private int frameCount;

    void Update()
    {
        time += Time.deltaTime;
        
        frameCount++;

        if(time >= pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            FpsText.text = frameRate.ToString() + " FPS";

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
