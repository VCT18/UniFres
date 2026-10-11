using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    private bool isGameOver = false;
    private float timer = 0f;
    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (isGameOver) return;

        if (timer >= 1f)
        {
            ScoreManager.Instance.AddScore(1);
            timer = 0f; 
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private void Start()
    {
        GameEvents.Instance.OnGameOver += GameOver;
        GameEvents.Instance.OnScoreChanged += UpdateScoreUI;
    }
    void OnDestroyOnDisable()
    {
        GameEvents.Instance.OnGameOver -= GameOver;
        GameEvents.Instance.OnScoreChanged -= UpdateScoreUI;
    }

    void UpdateScoreUI(int newScore)
    {
        scoreText.text = $"Score: {newScore}";
    }
    public void GameOver()
    {
        isGameOver = true;
        gameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}