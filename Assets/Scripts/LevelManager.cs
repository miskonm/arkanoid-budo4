using System;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int _blocksCount;

    public event Action OnAllBlocksDestroyed;

    private void Awake()
    {
        Block.OnCreated += BlockCreated;
        Block.OnDestroyed += BlockDestroyed;
    }

    private void OnDestroy()
    {
        Block.OnDestroyed -= BlockDestroyed;
        Block.OnCreated -= BlockCreated;
    }

    private void BlockCreated(Block block)
    {
        _blocksCount++;
    }

    private void BlockDestroyed(Block block, int score)
    {
        FindObjectOfType<GameManager>().AddScore(score);
        
        _blocksCount--;

        if (_blocksCount == 0)
        {
            OnAllBlocksDestroyed?.Invoke();
        }
    }
}