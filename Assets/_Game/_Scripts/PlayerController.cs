using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField] private Rigidbody2D m_playerRb;
    [SerializeField] private float m_addForce;
    [SerializeField] private float m_punchScaleSize = 0.1f;
    [SerializeField] private float m_tweenDuration = .5f;
    private Transform m_transform;
    #endregion Variables

    #region Unity Methods
    private void Awake()
    {
        m_transform = transform;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_playerRb.velocity = Vector2.zero;
            m_transform.DOComplete();
            m_transform.DOPunchScale(Vector2.one * m_punchScaleSize, m_tweenDuration).SetEase(Ease.InOutQuad);
            m_playerRb.AddForce(Vector2.up * m_addForce, ForceMode2D.Impulse);
            Debug.Log($"Force Added: {m_playerRb.velocity}");
        }
    }
    #endregion Unity Methods

    #region Public Methods

    #endregion Public Methods

    #region Private Methods

    #endregion Private Methods

    #region Callbacks

    #endregion Callbacks
}
