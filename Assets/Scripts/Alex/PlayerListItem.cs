//---------------------------------------------------------------------------------------------------------------//
//-------Alex Zarenko - Hochschule Darmstadt - Expanded Realities 2022 - Semester 6 Project ---------------------//
//---------------------------------------------------------------------------------------------------------------//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PlayerListItem : MonoBehaviourPunCallbacks
{
    // setting up Player Items with Nicknames
    [SerializeField] TMP_Text text; 
    Player player;
    public void SetUp(Player _player)
    {
        player = _player;
        text.text = _player.NickName;
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        //comparing if our player is the same as the other player, then destroy when we left the room
        if(player == otherPlayer)
        {
            Destroy(gameObject);
        }
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }
}
