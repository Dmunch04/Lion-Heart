using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HostGame : MonoBehaviour {

    public Text errorText;

    public GameObject legend1;
    public GameObject legend2;
    public GameObject legend3;
    public GameObject legend4;
    public GameObject legend5;
    public GameObject legend6;
    public GameObject legend7;
    public GameObject legend8;
    public GameObject legend9;
    public GameObject legend10;

    [SerializeField]
    private uint matchSize = 10;

    private string matchName;

    private NetworkManager networkManager;

    void Start()
    {
        networkManager = NetworkManager.singleton;

        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
    }

    public void SetMatchName (string _name)
    {
        matchName = _name;
    }

    #region Set Legends
    public void Legend1 ()
    {
        networkManager.playerPrefab = legend1;
    }

    public void Legend2()
    {
        networkManager.playerPrefab = legend2;
    }

    public void Legend3()
    {
        networkManager.playerPrefab = legend3;
    }

    public void Legend4()
    {
        networkManager.playerPrefab = legend4;
    }

    public void Legend5()
    {
        networkManager.playerPrefab = legend5;
    }

    public void Legend6()
    {
        networkManager.playerPrefab = legend6;
    }

    public void Legend7()
    {
        networkManager.playerPrefab = legend7;
    }

    public void Legend8()
    {
        networkManager.playerPrefab = legend8;
    }

    public void Legend9()
    {
        networkManager.playerPrefab = legend9;
    }

    public void Legend10()
    {
        networkManager.playerPrefab = legend10;
    }
    #endregion

    public void SetLegend (string legendName)
    {

    }

    public void MakeMatch ()
    {
            Debug.Log("Creating Match: " + matchName + " with room for " + matchSize + " players.");

            networkManager.matchMaker.CreateMatch("*NAME*", matchSize, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
            //errorText.text = "Please wait for players!";
    }

    public void CreateMatch ()
    {
        if (matchName != "" && matchName != null)
        {
            Debug.Log("Creating Match: " + matchName + " with room for " + matchSize + " players.");

            networkManager.matchMaker.CreateMatch(matchName, matchSize, true, "", "", "", 0, 0, networkManager.OnMatchCreate);
        }
        else
        {
            errorText.text = "Please give the match a name!";
        }
    }

}
