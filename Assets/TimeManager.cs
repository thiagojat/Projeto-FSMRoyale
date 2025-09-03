using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [Range(0, 5)] public float timeScale;
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
    }
}
