using System;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Variables

    [SerializeField] private int _startHp;
    [SerializeField] private bool _needAutoPlay;

    private int _hp;

    #endregion


    #region Events

    public event Action<int> OnScoreChanged;
    public event Action<int> OnHpChanged;
    public event Action OnGameWon;
    public event Action OnGameOver;

    #endregion


    #region Properties

    public bool NeedAutoPlay => _needAutoPlay;
    public int Score { get; private set; }

    public int Hp
    {
        get => _hp;
        set
        {
            if (value == _hp)
                return;

            _hp = value;
            OnHpChanged?.Invoke(_hp);
        }
    }

    #endregion


    #region Unity lifecycle

    protected override void Awake()
    {
        base.Awake();

        Hp = _startHp;
    }

    private void Start()
    {
        LevelManager.Instance.OnAllBlocksDestroyed += PerformWin;
    }

    private void OnDestroy()
    {
        LevelManager.Instance.OnAllBlocksDestroyed -= PerformWin;
    }

    #endregion


    #region Public methods

    public void ChangeScore(int score)
    {
        Score += score;
        OnScoreChanged?.Invoke(Score);
    }

    public void PerformWin()
    {
        Debug.LogError($"WIN!");
        // Todo: Add real logic

        OnGameWon?.Invoke();
    }

    public void LoseLife()
    {
        Hp--;
        FindObjectOfType<Ball>().ToDefaultState();

        if (Hp == 0)
        {
            OnGameOver?.Invoke();
        }
    }

    #endregion
}