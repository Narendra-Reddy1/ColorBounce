using BenStudios;
using BenStudios.EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitScene : MonoBehaviour
{
    #region Variables

    #endregion Variables

    #region Unity Methods
    private void Start()
    {

        SceneManager.LoadSceneAsync(Constants.PersistentManagers, LoadSceneMode.Additive).completed += (handle) =>
        {
            if (handle.isDone)
            {
                SceneManager.LoadSceneAsync(Constants.MainScene, LoadSceneMode.Additive).completed += (handle) =>
                {
                    ScreenManager.Instance.ChangeScreen(Window.MainMenu, ScreenType.Additive, onComplete: () =>
                    {
                        SceneManager.UnloadSceneAsync(Constants.InitScene);
                    });
                };
                GlobalEventHandler.TriggerEvent(EventID.REQUEST_TO_CONNECT_SERVER);
            }
        };
    }
    #endregion Unity Methods

    #region Public Methods

    #endregion Public Methods

    #region Private Methods

    #endregion Private Methods

    #region Callbacks

    #endregion Callbacks
}
