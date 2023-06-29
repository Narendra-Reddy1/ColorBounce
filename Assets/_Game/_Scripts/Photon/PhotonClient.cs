using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using BenStudios.EventSystem;
using UnityEngine.Diagnostics;
using BenStudios.Utils;
using Photon.Realtime;

namespace BenStudios
{
    public class PhotonClient : MonoBehaviourPunCallbacks
    {
        #region Variables

        #endregion Variables

        #region Unity Methods
        public override void OnEnable()
        {
            base.OnEnable();
            GlobalEventHandler.AddListener(EventID.REQUEST_TO_CONNECT_SERVER, CallbackOnConnecteToServerRequested);
            GlobalEventHandler.AddListener(EventID.REQUEST_TO_JOIN_RANDOM_ROOM, CalbackOnJoinRandomRoomRequested);
        }

        public override void OnDisable()
        {
            base.OnDisable();
            GlobalEventHandler.RemoveListener(EventID.REQUEST_TO_CONNECT_SERVER, CallbackOnConnecteToServerRequested);
            GlobalEventHandler.RemoveListener(EventID.REQUEST_TO_JOIN_RANDOM_ROOM, CalbackOnJoinRandomRoomRequested);

        }
        #endregion Unity Methods

        #region Public Methods

        #endregion Public Methods

        #region Private Methods

        #endregion Private Methods

        #region PhotonCallbacks
        public override void OnConnected()
        {
            base.OnConnected();
            MyUtils.Log($"ConnectedToPhotonServer!!");
            GlobalEventHandler.TriggerEvent(EventID.EVENT_ON_CONNECTED_TO_SERVER);
        }

        #endregion PhotonCallbacks


        #region Callbacks
        private void CallbackOnConnecteToServerRequested(object args)
        {
            if (!PhotonNetwork.IsConnected)
                PhotonNetwork.ConnectUsingSettings();
        }
        private void CalbackOnJoinRandomRoomRequested(object args)
        {
         
        }

        public struct JoinRandomRoomProperties
        {
            ExitGames.Client.Photon.Hashtable expectedCustomRoomProperties;
            byte expectedMaxPlayers;
            byte matchmakingMode;
            TypedLobby typedLobby;
            string sqlLobbyFilter;
            string roomName;
            RoomOptions roomOptions;
            string[] expectedUsers;
        }
        #endregion Callbacks
    }
}