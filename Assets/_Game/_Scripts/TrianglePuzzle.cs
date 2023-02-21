using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrianglePuzzle : MonoBehaviour
{
    #region Variables
    [SerializeField] private List<Transform> m_triangleNodes;
    [SerializeField] private float moveFrequency = 0.1f;

    private Transform m_mainNode;
    private float counter = 0;
    #endregion Variables

    #region Unity Methods
    private void OnEnable()
    {
        m_mainNode = m_triangleNodes[0];
    }

    private void Update()
    {
        _MoveWithFrequency();
    }

    #endregion Unity Methods

    #region Public Methods

    #endregion Public Methods

    #region Private Methods
    private void _MoveNodes()
    {
        for (int i = 0, count = m_triangleNodes.Count; i < count; i++)
        {

        }
    }
    private void _MoveWithFrequency()
    {
        counter += Time.deltaTime;
        if (counter >= moveFrequency)
        {
            counter = 0;
            _MoveNodes();
        }
    }
    #endregion Private Methods

    #region Callbacks

    #endregion Callbacks
}
