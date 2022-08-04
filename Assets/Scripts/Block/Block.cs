using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    #region Variables

    [Header("Block")]
    [SerializeField] private int _score;

    [Header("Pick Up")]
    [Range(0f, 1f)]
    [SerializeField] private float _pickUpSpawnChance;
    [SerializeField] private PickUpInfo[] _pickUpInfoArray;
    
    [Header("Music")]
    [SerializeField] private AudioClip _audioClip;

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
        // change hp
        // if(hp == 0)
        // DestroyBlock();
        DestroyBlock();
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this, _score);
    }

    private void OnValidate()
    {
        if (_pickUpInfoArray == null || _pickUpInfoArray.Length == 0)
            return;

        foreach (PickUpInfo pickUpInfo in _pickUpInfoArray)
            pickUpInfo.UpdateName();
    }

    #endregion


    #region Public methods

    public virtual void DestroyBlock()
    {
        AudioPlayer.Instance.PlaySound(_audioClip);
        SpawnPickUp();
        Destroy(gameObject);
    }

    #endregion


    #region Private methods

    private void SpawnPickUp()
    {
        if (_pickUpInfoArray == null || _pickUpInfoArray.Length == 0)
            return;

        float random = Random.Range(0f, 1f);
        if (random > _pickUpSpawnChance)
            return;

        int chanceSum = 0;

        foreach (PickUpInfo pickUpInfo in _pickUpInfoArray)
        {
            chanceSum += pickUpInfo.SpawnChance;
        }

        int randomChance = Random.Range(0, chanceSum);
        int currentChance = 0;
        int currentIndex = 0;

        for (int i = 0; i < _pickUpInfoArray.Length; i++)
        {
            PickUpInfo pickUpInfo = _pickUpInfoArray[i];
            currentChance += pickUpInfo.SpawnChance;

            if (currentChance >= randomChance)
            {
                currentIndex = i;
                break;
            }
        }

        PickUpBase pickUpPrefab = _pickUpInfoArray[currentIndex].PickUpPrefab;
        Instantiate(pickUpPrefab, transform.position, Quaternion.identity);
    }

    #endregion
}