using System;

public class LevelManager : SingletonMonoBehaviour<LevelManager>
{
    private int _blocksCount;

    public event Action OnAllBlocksDestroyed;

    protected override void Awake()
    {
        base.Awake();
        
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
        GameManager.Instance.ChangeScore(score);
        
        _blocksCount--;

        if (_blocksCount == 0)
            OnAllBlocksDestroyed?.Invoke();
    }
}