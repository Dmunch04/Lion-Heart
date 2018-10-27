using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;

public class JoinGame : MonoBehaviour {

    List<GameObject> matchList = new List<GameObject>();

    [SerializeField]
    private Text status;

    [SerializeField]
    private GameObject matchListItemPrefab;

    [SerializeField]
    private Transform matchListParent;

    private NetworkManager networkManager;

    public GameObject hostScreen;
    public GameObject joinScreen;

    public Image switchButtonImage;

    void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }

        RefreshMatchList();
    }

    public void SwitchToHost()
    {
        if (hostScreen.gameObject.activeInHierarchy == false)
        {
            hostScreen.gameObject.SetActive(true);
            joinScreen.gameObject.SetActive(false);
            switchButtonImage.transform.Rotate(new Vector3(0, 0, 180));
        }
        else
        {
            hostScreen.gameObject.SetActive(false);
            joinScreen.gameObject.SetActive(true);
            switchButtonImage.transform.Rotate(new Vector3(0, 0, -180));
        }
    }

    public void RefreshMatchList()
    {
        ClearMatchList();

        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }

        networkManager.matchMaker.ListMatches(0, 20, "", true, 0, 0, OnMatchList);
        status.text = "Loading...";
    }

    public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
    {
        status.text = "";

        if (!success || matchList == null)
        {
            status.text = "Couldn't find any matches. Try again!";
            return;
        }

        foreach (MatchInfoSnapshot match in matchList)
        {
            GameObject _matchListItemGO = Instantiate(matchListItemPrefab);
            _matchListItemGO.transform.SetParent(matchListParent);

            MatchListItem _matchListItem = _matchListItemGO.GetComponent<MatchListItem>();
            if (_matchListItem != null)
            {
                _matchListItem.Setup(match, JoinMatch);
            }


            // as well as setting up a callback function that will join the game.

            //matchList.Add(_matchListItemGO);
        }

        if (matchList.Count == 0)
        {
            status.text = "No matches at the moment.";
        }
    }

    void ClearMatchList()
    {
        for (int i = 0; i < matchList.Count; i++)
        {
            Destroy(matchList[i]);
        }

        matchList.Clear();

		//removes existing match items
		foreach(Transform child in matchListParent) {
			Destroy(child.gameObject);
		}


    }

    public void JoinMatch(MatchInfoSnapshot _match)
    {
        networkManager.matchMaker.JoinMatch(_match.networkId, "", "", "", 0, 0, networkManager.OnMatchJoined);
        StartCoroutine(WaitForJoin());
    }

    IEnumerator WaitForJoin()
    {
        ClearMatchList();

        int countdown = 1;
        while (countdown > 0)
        {
            status.text = "JOINING... (" + countdown + ")";

            yield return new WaitForSeconds(1);

            countdown--;
        }

        // Failed to connect
        status.text = "Failed to connect.";
        yield return new WaitForSeconds(1);

        MatchInfo matchInfo = networkManager.matchInfo;
        if (matchInfo != null)
        {
            networkManager.matchMaker.DropConnection(matchInfo.networkId, matchInfo.nodeId, 0, networkManager.OnDropConnection);
            networkManager.StopHost();
        }

        RefreshMatchList();

    }

}
