using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;
    private void Awake()
    {
        Instance = this;
    }
    public event Action OnGameOver;
    public event Action<int> OnScoreChanged;

    public void TriggerGameOver()
    {
        OnGameOver?.Invoke();
    }
    public void TriggerScoreChanged(int newScore)
    {
        OnScoreChanged?.Invoke(newScore);
    }

}
