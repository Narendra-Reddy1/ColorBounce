/// <summary>
/// All events to be used need to be added to this script.
/// </summary>
/// 
namespace BenStudios.EventSystem
{
    #region Event Types enum
    public enum EventID
    {

        //Level
        EVENT_ON_LEVEL_STARTED,
        EVEN_ON_LEVEL_FINISHED,
        EVENT_ON_LEVEL_EXITED,
        EVENT_RESTART_LEVEL_REQUESTED,

        //Player
        EVENT_ON_PLAYER_WIN,

        //PHOTON NETWORK
        REQUEST_TO_CONNECT_SERVER,
        EVENT_ON_CONNECTED_TO_SERVER,
        EVENT_ON_CONNECTED_TO_MASTER,

        REQUEST_TO_JOIN_ROOM,
        REQUEST_TO_LEAVE_ROOM,
        REQUEST_TO_JOIN_RANDOM_ROOM,
        EVENT_ON_ROOM_CREATED,
        EVENT_ON_CREATE_ROOM_FAILED,
        EVENT_ON_JOINED_ROOM,
        EVENT_ON_JOIN_RANDOM_ROOM_FAILED,
        
        EVENT_ON_JOINED_LOBBY,
        EVENT_ON_LEFT_LOBBY,
        EVENT_ON_PLAYER_LEFT,
        EVENT_ON_PLAYER_ENTERED,


        //Gameplay
        EVENT_ON_NEW_CHECKPOINT_REACHED,
        REQUEST_TO_SETUP_NEW_CHECKPOINT,

        //ScreenManager
        EVENT_ON_CHANGE_SCREEN_REQUESTED,
        EVENT_REQUEST_TO_CHANGE_SCREEN_WITH_TRANSITION,
        EVENT_ON_REMOVE_ALL_SCREENS_REQUESTED,
        EVENT_ON_CLOSE_LAST_ADDITIVE_SCREEN,
        EVENT_REQUEST_GENERIC_POPUP_SETUP,
        EVENT_REQUEST_SCREEN_TRANSITION,
        EVENT_REQUEST_GET_CURRENT_SCREEN,
        EVENT_REQUEST_GE_PREVIOUS_SCREEN,


        //Fade Screen
        EVENT_REQEST_FADE_SCREEN_IN,
        EVENT_REQEST_FADE_SCREEN_OUT,
        EVENT_REQUEST_SCREEN_BLINK,
        EVENT_REQUEST_SCREEN_BLOCK,
        EVENT_REQUEST_SCREEN_UNBLOCK,
        EVENT_REQUEST_TO_KILL_TURN_TIMER_TWEENING,

        ////ADS 
        EVENT_ON_SHOW_BANNER_AD_REQUESTED,
        EVENT_ON_HIDE_BANNER_AD_REQUESTED,
        EVENT_ON_LOAD_MREC_AD_REQUESTED,
        EVENT_ON_SHOW_MREC_AD_REQUESTED,
        EVENT_ON_HIDE_MREC_AD_REQUESTED,
        EVENT_ON_SHOW_INTERSTITIAL_AD_REQUESTED,
        EVENT_ON_SHOW_REWARDED_AD_REQUESTED,
        EVENT_ON_LOAD_APP_OPEN_AD_REQUESTED,
        EVENT_ON_SHOW_APP_OPEN_AD_REQUESTED,
        EVENT_ON_APP_OPEN_AD_AVAILABILITTY_REQUESTED,
        EVENT_ON_REWARDED_AD_AVAILABILITY_REQUESTED,
        EVENT_ON_INTERSTITIAL_AD_AVAILABILITY_REQUESTED,

        //Ad State
        EVENT_ON_AD_STATE_CHANGED,

        //SelectionScreen
        EVENT_ON_DIFFICULTY_LEVEL_SELECTED,
        EVENT_ON_PLAYER_RESPAWNED,

    }
    #endregion
}