//---------------------------------------------------------------------------------------------------------------//
//-------Alex Zarenko - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project - 03.06.2022 --------//
//---------------------------------------------------------------------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using System.Linq;

public class PhotonLauncher : MonoBehaviourPunCallbacks
{
    public static PhotonLauncher Instance;

    [SerializeField] HardwareChecker hardwareChecker;
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] Transform roomListContent;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] GameObject playerListItemPrefab;
    [SerializeField] GameObject startGameButton;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Debug.Log("Connecting to Server...");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        // callback called by Photon when successfully connected to Master Server
        //base.OnConnectedToMaster();  
        Debug.Log("Connected to Master.");
        PhotonNetwork.JoinLobby();

        // sync scenes automatically, if the host changes scenes
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby.");
        MenuManager.Instance.OpenMenu("title");

        if (hardwareChecker.caveSetupPresent == false)
        {
           //Activate the corresponding player (VR)
            PhotonNetwork.NickName = "VR Player " + Random.Range(0, 1000).ToString("0000");
        }
        else if (hardwareChecker.caveSetupPresent == true)
        {
            //Activate the corresponding player (CAVE)
            PhotonNetwork.NickName = "CAVE Player " + Random.Range(0, 1000).ToString("0000");
        }

        //PhotonNetwork.NickName = "Player " + Random.Range(0, 1000).ToString("0000");
    }

    public void CreateRoom()
    {
        // making sure a Room Name is entered, or return
        //if (string.IsNullOrEmpty(roomNameInputField.text))
        //{
        //    return;
        //}
        //PhotonNetwork.CreateRoom(roomNameInputField.text);
        //MenuManager.Instance.OpenMenu("loading");

        // creating room with random number as a name (instead of using the InputField)
        PhotonNetwork.CreateRoom(Random.Range(0, 1000).ToString("0000"));
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnJoinedRoom()
    {
        // assigns the PhotonNetwork Room name to our string in the menu
        MenuManager.Instance.OpenMenu("room");
        roomNameText.text = "ROOM NAME: " + PhotonNetwork.CurrentRoom.Name;


        Player[] players = PhotonNetwork.PlayerList;

        // clear playerlist when leaving the room
        foreach(Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Count(); i++)
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);
        }

        // checking if master client, if true, you have access to the Start Game Button
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);

        // checking if you are the cave player, if true, you have access to the Start Game Button
        //startGameButton.SetActive(hardwareChecker.caveSetupPresent == true);
    }

    // if the Master client left the game, Master client will be automatically switched
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        // new Master client receives the startGameButton access
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "ERROR! ROOM CREATION FAILED: " + message;
        MenuManager.Instance.OpenMenu("error");
    }

    public void StartGame()
    {
        // using Photon Loadlevel instead of SceneManager, so all Players can load scenes at the same time
        PhotonNetwork.LoadLevel(1);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("loading");
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.Instance.OpenMenu("loading");
    }

    public override void OnLeftRoom()
    {
        MenuManager.Instance.OpenMenu("title");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach(Transform trans in roomListContent)
        {   
            //clearing the List every time we get an Update
            Destroy(trans.gameObject);
        }
        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
            {
                continue;
            }
            //instantiating roomListItemPrefab in the roomListContent container, and setting it up with a Photon Room Info
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
    }
}
