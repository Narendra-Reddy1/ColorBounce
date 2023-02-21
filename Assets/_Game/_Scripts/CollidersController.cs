using BenStudios.Enums;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BenStudios
{


    public class CollidersController : MonoBehaviour
    {

        //[Tooltip("Place 0.Pink 1.Blue 2.Yellow 3.Cyan")]
        //[SerializeField] private List<GameObject> m_colliderTransforms;
        //[SerializeField] private ColorCollidersDictionary coloColliders;
        [SerializeField] private List<ColliderList> colorColliders;
        private void Start()
        {
            _EnablePlayerColorCollider();
        }
        private void _EnablePlayerColorCollider()
        {
            colorColliders.Find(x => x.color == GlobalVariables.currentPlayerColor).colliderList.ForEach(x => x.SetActive(false));
            // coloColliders[GlobalVariables.currentPlayerColor].ForEach(x => x.SetActive(false));
            //m_colliderTransforms[(int)GlobalVariables.currentPlayerColor].SetActive(false);
        }
    }
    [System.Serializable]
    public class ColliderList
    {
        public PlayerColor color;
        public List<GameObject> colliderList;
    }
}