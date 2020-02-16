using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MenuManager : MonoBehaviour
{
    private Canvas canvas = null;
    public SteamVR_Action_Boolean PreviousAction;
    public Panel currentPanel = null;
    public List<Panel> panelHistory = new List<Panel>();
    private void Start(){
        canvas = GetComponent<Canvas>();
        SetupPanels();
        PreviousAction.AddOnStateDownListener(GoToPrevious, SteamVR_Input_Sources.Any);
    }
    private void SetupPanels(){
        Panel[] panels = GetComponentsInChildren<Panel>();
        foreach (Panel panel in panels){
            panel.Setup(this);
        }

        currentPanel.Show();
    }

    public void GoToPrevious(){
        GoToPrevious(null, SteamVR_Input_Sources.Any);
    }
    public void GoToPrevious(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource){
        if(panelHistory.Count == 0){
            Debug.Log("Back pressed when history is empty");
            return;
        }
        int lastIndex = panelHistory.Count - 1;
        SetCurrent(panelHistory[lastIndex]);
        panelHistory.RemoveAt(lastIndex);
    }

    public void SetCurrentWithHistory(Panel newPanel){
        panelHistory.Add(currentPanel);
        SetCurrent(newPanel);
    }

    private void SetCurrent(Panel newPanel){
        currentPanel.Hide();
        currentPanel = newPanel;
        currentPanel.Show();
    }
}
