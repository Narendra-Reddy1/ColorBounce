using BenStudios.Enums;
using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField] private Rigidbody2D m_playerRb;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private ParticleSystem deathParticleSystem;
    [SerializeField] private float m_addForce;
    [SerializeField] private float punchScaleSize = 0.1f;
    [SerializeField] private float tweenDuration = .5f;
    private Transform m_transform;
    #endregion Variables

    #region Unity Methods
    private void Awake()
    {
        Init();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_playerRb.velocity = Vector2.zero;
            m_transform.DOComplete();
            m_transform.DOPunchScale(Vector2.one * punchScaleSize, tweenDuration).SetEase(Ease.InOutQuad);
            m_playerRb.AddForce(Vector2.up * m_addForce, ForceMode2D.Impulse);
            Debug.Log($"Force Added: {m_playerRb.velocity}");
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag == "Obstacle")
        {
            Debug.Log($"Obstacle Hit");
            _ShowPlayerDeathEffect();
        }
    }
    #endregion Unity Methods

    #region Public Methods
    public void Init()
    {
        m_transform = transform;
        if (playerSpriteRenderer == null) TryGetComponent(out playerSpriteRenderer);
        _InitPlayerColor();
    }

    #endregion Public Methods


    #region Private Methods
    private void _InitPlayerColor()
    {
        GlobalVariables.currentPlayerColor = (PlayerColor)Random.Range(0, 4);
        switch (GlobalVariables.currentPlayerColor)
        {
            case PlayerColor.Pink:
                playerSpriteRenderer.color = Constants.pinkColor;
                break;
            case PlayerColor.Blue:
                playerSpriteRenderer.color = Constants.blueColor;
                break;
            case PlayerColor.Yellow:
                playerSpriteRenderer.color = Constants.yellowColor;
                break;
            case PlayerColor.Cyan:
                playerSpriteRenderer.color = Constants.cyanColor;
                break;
            default:
                Debug.LogError($"Invalid Color to the player...");
                break;
        }
    }
    private void _ShowPlayerDeathEffect()
    {
        playerSpriteRenderer.enabled = false;
        deathParticleSystem.Play();

    }
    #endregion Private Methods

    #region Callbacks

    #endregion Callbacks
}
