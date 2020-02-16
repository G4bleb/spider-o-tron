using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MenuManager : MonoBehaviour
{
    public Panel currentPanel = null;
    public List<Panel> panelHistory = new List<Panel>();
    private void Start(){
        SetupPanels();
    }

    private void SetupPanels(){
        Panel[] panels = GetComponentsInChildren<Panel>();
        foreach (Panel panel in panels){
            panel.Setup(this);
        }

        currentPanel.Show();
    }

    private void Update(){
        if(SteamVR_Actions._default.GrabGrip.state){
            GoToPrevious();
        }

    }

    public void GoToPrevious(){
        if(panelHistory.Count == 0){
            Debug.Log("Back pressed when history is empty");
            Debug.Log("We should probably ask to quit app");
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
