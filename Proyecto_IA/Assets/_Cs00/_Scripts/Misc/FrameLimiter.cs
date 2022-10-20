using UnityEngine;
public class FrameLimiter : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 60;
    }
}
