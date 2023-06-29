using BenStudios.EventSystem;
using Coffee.UIExtensions;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Checkpoint : MonoBehaviour, IInitializer
{
    #region Variables

    [SerializeField] private Collider2D m_checkpointCollider;
    [SerializeField] private GameObject m_checkpointTxt;
    [SerializeField] private UIParticleAttractor m_particleAttractor;

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
        if (m_checkpointCollider == null) TryGetComponent(out m_checkpointCollider);
        m_particleAttractor.enabled = false;
    }
    public void Release()
    {
        m_particleAttractor.particleSystems.Clear();
        gameObject.SetActive(false);
    }
    #endregion Public Methods

    #region Private Methods

    private void _OnCheckpointReached()
    {
        Destroy(m_checkpointCollider);
        m_checkpointTxt.SetActive(false);
        m_particleAttractor.particleSystems.Clear();
        m_particleAttractor.particleSystems.Add(GlobalVariables.playerParticleSystem);
        m_particleAttractor.enabled = true;
    }
    #endregion Private Methods

    #region Callbacks
    private void Callback_On_New_Checkpoint_Reached(object args)
    {
        if (GlobalVariables.currentCheckpoint.transform != transform) return;
        _OnCheckpointReached();
    }

    #endregion Callbacks
}
