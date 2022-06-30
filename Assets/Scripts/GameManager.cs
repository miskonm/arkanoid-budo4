using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private Ball _ball;

    private bool _isStarted;

    #endregion


    #region Properties

    public int Score { get; private set; }

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        FindObjectOfType<LevelManager>().OnAllBlocksDestroyed += PerformWin; // TODO: Use singleton
    }

    private void OnDestroy()
    {
        FindObjectOfType<LevelManager>().OnAllBlocksDestroyed -= PerformWin; // TODO: Use singleton
    }

    private void Update()
    {
        if (_isStarted)
            return;

        _ball.MoveWithPad();

        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }
    }

    #endregion


    #region Public methods

    public void AddScore(int score)
    {
        Score += score;
        // Invoke event
    }

    public void PerformWin()
    {
        Debug.LogError($"WIN!");
        // Todo: Add real logic
    }

    #endregion


    #region Private methods

    private void StartBall()
    {
        _isStarted = true;
        _ball.StartMove();
    }

    #endregion
}