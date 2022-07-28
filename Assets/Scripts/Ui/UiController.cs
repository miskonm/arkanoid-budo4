using UnityEngine;

public class UiController : MonoBehaviour
{
    [SerializeField] private GameObject _winScreen;
    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _pauseScreen;

    private void Awake()
    {
        _winScreen.SetActive(false);
        _gameOverScreen.SetActive(false);
        _pauseScreen.SetActive(false);
    }

    private void Start()
    {
        PauseManager.Instance.OnPaused += Paused;
        GameManager.Instance.OnGameOver += GameOver;
        GameManager.Instance.OnGameWon += GameWon;
    }

    private void OnDestroy()
    {
        PauseManager.Instance.OnPaused -= Paused;
        GameManager.Instance.OnGameOver -= GameOver;
        GameManager.Instance.OnGameWon -= GameWon;
    }

    private void Paused(bool isPaused) =>
        _pauseScreen.SetActive(isPaused);

    private void GameWon() =>
        _winScreen.SetActive(true);

    private void GameOver() =>
        _gameOverScreen.SetActive(true);
}