using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodesMovement : MonoBehaviour
{

    #region Variables
    [SerializeField] private float moveFrequency = 0.1f;
    [SerializeField] private List<Transform> m_nodesList;
    private Transform m_mainNode;
    private float counter = 0;
    #endregion Variables

    #region Unity Methods
    private void OnEnable()
    {
        m_mainNode = m_nodesList[0];
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
        Vector3 mainNodePosition = m_mainNode.position;
        Vector3 prevPosition;
        m_mainNode.position = m_nodesList[m_nodesList.Count - 1].position;
       
        for (int i = 1, count = m_nodesList.Count; i < count; i++)
        {
            prevPosition = m_nodesList[i].position;
            m_nodesList[i].position = mainNodePosition;
            mainNodePosition = prevPosition;
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
