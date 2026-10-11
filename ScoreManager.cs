using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private int score = 0;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        GameEvents.Instance.OnGameOver += HandleGameOver;
    }
    
    void OnDestroy()
    {
        GameEvents.Instance.OnGameOver -= HandleGameOver;
    }

    void HandleGameOver()
    {
        Debug.Log($"Điểm cuối: {score}");
    }
    public void AddScore(int amount)
    {
        score += amount;
        GameEvents.Instance.TriggerScoreChanged(score);
    }

}
