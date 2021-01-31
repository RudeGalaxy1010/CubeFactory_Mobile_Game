using UnityEngine;

// Game time controller to better time manipulations

public class GameTime : MonoBehaviour
{
    public static GameTime Instance;
    public bool isBaseTimeScale => Time.timeScale == baseTimeScale ? true : false;

    [SerializeField] private float slowMotionTimeSpeed = 0.25f;
    [SerializeField] private float baseTimeScale = 1;

    private bool isPaused;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        isPaused = false;
        Time.timeScale = baseTimeScale;
    }

    public void SlowDown()
    {
        Time.timeScale = slowMotionTimeSpeed;
    }

    public void Normalize()
    {
        Time.timeScale = baseTimeScale;
    }

    public void SetPause(bool isPause)
    {
        if (isPause)
        {
            Time.timeScale = 0;
            isPaused = true;
        }
        else
        {
            Time.timeScale = baseTimeScale;
            isPaused = false;
        }
    }

    public void SwitchPause()
    {
        SetPause(!isPaused);
    }
}
