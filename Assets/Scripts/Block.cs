using System;
using UnityEngine;

public class Block : MonoBehaviour
{
    #region Variables

    [SerializeField] private int _score;

    #endregion


    #region Events

    public static event Action<Block> OnCreated;
    public static event Action<Block, int> OnDestroyed;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        OnCreated?.Invoke(this);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Add score
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this, _score);
    }

    #endregion
}