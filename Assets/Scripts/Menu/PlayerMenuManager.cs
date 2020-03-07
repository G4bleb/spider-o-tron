using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerMenuManager : MenuManager
{
    private Canvas canvas = null;
    public SteamVR_Action_Boolean PreviousAction;
    // public Panel currentPanel = null;
    // public List<Panel> panelHistory = new List<Panel>();

    override protected void Start(){
        base.Start();
        PreviousAction.AddOnStateDownListener(GoToPrevious, SteamVR_Input_Sources.Any);
    }

    public void GoToPrevious(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource){
        base.GoToPrevious();
    }
}