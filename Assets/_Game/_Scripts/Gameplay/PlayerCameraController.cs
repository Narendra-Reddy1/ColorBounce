using UnityEngine;
using DG.Tweening;
using BenStudios.EventSystem;

public class PlayerCameraController : MonoBehaviour, IInitializer
{
    #region Variables
    [SerializeField] private Camera m_mainCamera;
    [SerializeField] private Transform m_target;

    #endregion Variables

    #region Unity Methods
    private void Awake()
    {
        Init();
    }
    private void OnEnable()
    {
        GlobalEventHandler.AddListener(EventID.EVENT_ON_PLAYER_RESPAWNED, Callback_On_PlayerRespawned);
    }
    private void OnDisable()
    {
        GlobalEventHandler.RemoveListener(EventID.EVENT_ON_PLAYER_RESPAWNED, Callback_On_PlayerRespawned);

    }
    #endregion Unity Methods

    #region Public Methods

    public void Init()
    {
        if (m_mainCamera == null) m_mainCamera = Camera.main;
        if (m_target == null) Debug.LogException(new System.Exception("TARGET NOT FOUND EXCEPTION: PlayerCameraController "));
    }

    private void LateUpdate()
    {
        _FollowTarget();
    }
    #endregion Public Methods

    #region Private Methods
    private void _FollowTarget()
    {
        Vector3 position = m_target.position;
        position.x = transform.position.x;
        position.z = transform.position.z;
        if (transform.position.y <= position.y)
        {
            transform.position = position;
        }
    }
    #endregion Private Methods

    #region Callbacks
    private void Callback_On_PlayerRespawned(object args)
    {
        transform.DOMoveY(m_target.position.y, .1f);
    }
    #endregion Callbacks
}
