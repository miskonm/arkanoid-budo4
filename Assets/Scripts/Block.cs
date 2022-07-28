using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Block : MonoBehaviour
{
    #region Variables

    [Header("Block")]
    [SerializeField] private int _score;

    [Header("Pick Up")]
    [SerializeField] private GameObject _pickUpPrefab;

    [Range(0f, 1f)]
    [SerializeField] private float _pickUpSpawnChance;

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
        SpawnPickUp();
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this, _score);
    }

    #endregion


    #region Private methods

    private void SpawnPickUp()
    {
        if (_pickUpPrefab == null)
            return;
        
        float random = Random.Range(0f, 1f);
        if (random <= _pickUpSpawnChance)
        {
            Instantiate(_pickUpPrefab, transform.position, Quaternion.identity);
        }
    }

    #endregion
}