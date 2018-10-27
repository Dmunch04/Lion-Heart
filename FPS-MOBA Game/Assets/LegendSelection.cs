using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LegendSelection : MonoBehaviour {

    // Creates the IsOn bool for the selection menu and sets it to true
    public static bool IsOn = true;

    //[SerializeField]
    //GameObject playerGraphicsPrefab;

    // Getting the network manager
    private NetworkManager nm;

    private ChangeModel cm;

    void Start ()
    {
        cm = GetComponent<ChangeModel>();

        nm = NetworkManager.singleton;
    }

    // This is a function for closing a game object. The game object is given in the inspector
    public void ClosePanel (GameObject disable)
    {
        // This will disable the game object you put in the inspector
        disable.SetActive(false);
    }

    // This is a function for opening a game object. The game object is given in the inspector
    public void OpenPanel (GameObject enable)
    {
        // This will enable the game object you put in the inspector
        enable.SetActive(true);
    }

    // This function will make the graphics, of the player that runs this, change
    public void SetPlayerGraphic (GameObject graphics)
    {
        // Here we check if it's the local player. If it's not then we return. We check this by looking in the PlaayerSetup script
        if (!PlayerSetup.IsLocalPlayer)
            return;

        //nm.playerPrefab = graphics;
    }

    public void SetLegend1 ()
    {
        cm.Switch1();
        GetComponent<ChangeModel>().Switch1();
    }

    public void SetLegend2 ()
    {
        if (!PlayerSetup.IsLocalPlayer)
            return;

        cm.Switch2();
    }

    public void SetLegend3 ()
    {
        if (!PlayerSetup.IsLocalPlayer)
            return;

        cm.Switch3();
    }

    public void SetLegend4()
    {
        if (!PlayerSetup.IsLocalPlayer)
            return;

        cm.Switch4();
    }

    public void SetLegend5 ()
    {
        if (!PlayerSetup.IsLocalPlayer)
            return;

        cm.Switch5();
    }

    public void SetLegend6()
    {
        if (!PlayerSetup.IsLocalPlayer)
            return;

        cm.Switch6();
    }

    public void SetLegend7 ()
    {
        if (!PlayerSetup.IsLocalPlayer)
            return;

        cm.Switch7();
    }

    public void SetLegend8 ()
    {
        if (!PlayerSetup.IsLocalPlayer)
            return;

        cm.Switch8();
    }

    public void SetLegend9 ()
    {
        if (!PlayerSetup.IsLocalPlayer)
            return;

        cm.Switch9();
    }
    public void SetLegend10 ()
    {
        if (!PlayerSetup.IsLocalPlayer)
            return;

        cm.Switch10();
    }


}
