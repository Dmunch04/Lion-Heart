using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class PauseMenu : MonoBehaviour {

    // Creates the IsOn bool for the pause menu and sets it to false
    public static bool IsOn = false;

    // Getting the network manager
    private NetworkManager nm;

    void Start()
    {
        nm = NetworkManager.singleton;
    }

    // In this function you resume the game
    public void ResumeGame ()
    {

    }

    // In this function you just leave the game. There's too much to explain
    public void LeaveGame ()
    {
        MatchInfo matchInfo = nm.matchInfo;

        nm.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, nm.OnDropConnection);
        nm.StopHost();
    }

}
