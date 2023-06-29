using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BenStudios;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

namespace BenStudios
{
    public class MainMenuScreen : ScreenBase
    {
        #region Variables
        [SerializeField] private Button startButton;
        [SerializeField] private TextMeshProUGUI startButtonText;

        #endregion Variables

        #region Unity Methods

        #endregion Unity Methods

        #region Public Methods
        public void OnClickStartButton()
        {
            JoinRandomRoom();
        }
        #endregion Public Methods

        #region Private Methods
        private void JoinRandomRoom()
        {
            PhotonNetwork.JoinRandomOrCreateRoom(expectedMaxPlayers: 2, roomOptions: new Photon.Realtime.RoomOptions() { IsVisible = true, IsOpen = true });
        }
        #endregion Private Methods

        #region Callbacks
        private void Callback_On_Joined_Room(object args)
        {

        }
        #endregion Callbacks
    }
}