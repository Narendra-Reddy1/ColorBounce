using BenStudios.Enums;
using BenStudios.EventSystem;
using Cinemachine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IInitializer
{
    #region Variables
    [SerializeField] private Rigidbody2D m_playerRb;
    [SerializeField] private Collider2D m_playerCollider;
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private ParticleSystem deathParticleSystem;
    [SerializeField] private Transform m_deathEffectPartent;
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
        if (Input.GetKeyUp(KeyCode.R))
        {
            _RespawnPlayer();
        }
        if (GlobalVariables.playerState is PlayerState.Dead) return;
        if (Input.GetMouseButtonDown(0))
        {
            if (m_playerRb.isKinematic)
                m_playerRb.isKinematic = false;
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
            _OnPlayerHitObstacle();
            _ShowPlayerDeathEffect();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"triggger");
        if (other.CompareTag("Checkpoint"))
        {
            GlobalVariables.currentCheckpoint = other.GetComponent<Checkpoint>();
            GlobalEventHandler.TriggerEvent(EventID.EVENT_ON_NEW_CHECKPOINT_REACHED);
        }
    }
    #endregion Unity Methods

    #region Public Methods
    public void Init()
    {
        m_transform = transform;
        if (playerSpriteRenderer == null) TryGetComponent(out playerSpriteRenderer);
        _InitPlayerColor();
        GlobalVariables.playerState = PlayerState.Alive;
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
        m_deathEffectPartent.transform.position = m_transform.position;
        deathParticleSystem.Play();
    }
    private void _OnPlayerHitObstacle()
    {
        GlobalVariables.playerState = PlayerState.Dead;
        m_playerRb.isKinematic = true;
        m_playerCollider.enabled = false;
        playerSpriteRenderer.enabled = false;
    }
    private void _RespawnPlayer()
    {
        m_transform.DOMoveY(GlobalVariables.currentCheckpoint.transform.position.y, .25f);
        m_playerCollider.enabled = true;
        playerSpriteRenderer.enabled = true;
        GlobalVariables.playerState = PlayerState.Alive;
    }

    #endregion Private Methods

    #region Callbacks
    #endregion Callbacks
}
