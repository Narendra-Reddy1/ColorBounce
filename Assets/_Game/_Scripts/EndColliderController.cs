using BenStudios.EventSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndColliderController : MonoBehaviour
{
    #region Variables
    #endregion Variables

    #region Unity Methods

    private void OnEnable()
    {
        GlobalEventHandler.AddListener(EventID.EVENT_ON_NEW_CHECKPOINT_REACHED, Callback_On_New_Checkpoint_Reached);
    }
    private void OnDisable()
    {
        GlobalEventHandler.RemoveListener(EventID.EVENT_ON_NEW_CHECKPOINT_REACHED, Callback_On_New_Checkpoint_Reached);

    }
    #endregion Unity Methods

    #region Public Methods

    #endregion Public Methods

    #region Private Methods

    #endregion Private Methods

    #region Callbacks


    private void Callback_On_New_Checkpoint_Reached(object args)
    {
        Vector3 position = GlobalVariables.currentCheckpoint.transform.position;
        position.y -= 2;
       // transform.position = position;
    }
    #endregion Callbacks
}
