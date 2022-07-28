using System;
using UnityEngine;

public class PauseManager : SingletonMonoBehaviour<PauseManager>
{
    #region Events

    public event Action<bool> OnPaused;

    #endregion


    #region Properties

    public bool IsPaused { get; private set; }

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    #endregion


    #region Private methods

    private void TogglePause()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0 : 1;
        OnPaused?.Invoke(IsPaused);
    }

    #endregion
}