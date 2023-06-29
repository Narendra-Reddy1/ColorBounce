using BenStudios.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BenStudios
{


    public class CollidersController : MonoBehaviour
    {
        #region Variables

        [SerializeField] private List<ColliderList> colorColliders;

        #endregion Variables

        #region Unity Methods

        private void Start()
        {
            _EnablePlayerColorCollider();
        }
        #endregion Unity Methods

        #region Private Methods

        private void _EnablePlayerColorCollider()
        {
            colorColliders.Find(x => x.color == GlobalVariables.currentPlayerColor).colliderList.ForEach(x => x.SetActive(false));
        }
        private void ResetAllColliders()
        {
            colorColliders.Find(x => x.color == GlobalVariables.currentPlayerColor).colliderList.ForEach(x => x.SetActive(true));
        }
        #endregion Private Methods

        #region Callbacks
        private void Callback_On_Player_Color_Changed(object args)
        {
            ResetAllColliders();
            _EnablePlayerColorCollider();
        }
        #endregion Callbacks
    }
    [System.Serializable]
    public class ColliderList
    {
        public PlayerColor color;
        public List<GameObject> colliderList;
    }
}