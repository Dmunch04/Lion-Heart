using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking.Match;

public class MatchListItem : MonoBehaviour {

    public delegate void JoinMatchDelegate(MatchInfoSnapshot _match);
    private JoinMatchDelegate joinMatchCallback;

    [SerializeField]
    private Text matchNameText;

    private MatchInfoSnapshot match;

    public void Setup (MatchInfoSnapshot _match, JoinMatchDelegate _joinMatchCallback)
    {
        match = _match;
        joinMatchCallback = _joinMatchCallback;

        matchNameText.text = match.name + " (" + match.currentSize + "/" + match.maxSize + ")";
    }

    public void JoinGame ()
    {
        joinMatchCallback.Invoke(match);
    }

}
