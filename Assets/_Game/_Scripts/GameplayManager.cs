using BenStudios.EventSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour, IInitializer
{
    #region Variables
    [SerializeField] private ParticleSystem m_checkpointParticleSystem;
    [SerializeField] private ParticleSystem m_playerParticleSystem;
    [SerializeField] private Checkpoint m_initialPoint;

    #endregion Variables

    #region Unity Methods
    private void OnEnable()
    {
        Init();
        GlobalEventHandler.AddListener(EventID.EVENT_ON_NEW_CHECKPOINT_REACHED, Callback_On_New_Checkpoint_Reached);
    }
    private void OnDisable()
    {
        GlobalEventHandler.RemoveListener(EventID.EVENT_ON_NEW_CHECKPOINT_REACHED, Callback_On_New_Checkpoint_Reached);
    }

    #endregion Unity Methods

    #region Public Methods

    public void Init()
    {
        var main = m_playerParticleSystem.main;
        main.simulationSpace = ParticleSystemSimulationSpace.Local;
        GlobalVariables.currentCheckpoint = m_initialPoint;
        GlobalVariables.playerParticleSystem = m_playerParticleSystem;
    }
    #endregion Public Methods

    #region Private Methods
    private void _OnNewChecpointReached()
    {
        m_checkpointParticleSystem.transform.position = GlobalVariables.currentCheckpoint.transform.position;
        m_checkpointParticleSystem.Play();
    }

    #endregion Private Methods

    #region Callbacks
    private void Callback_On_New_Checkpoint_Reached(object args)
    {
        _OnNewChecpointReached();
    }

    #endregion Callbacks
}
