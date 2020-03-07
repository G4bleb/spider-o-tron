using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MenuManager : MonoBehaviour
{
    private Canvas canvas = null;
    public Panel currentPanel = null;
    public List<Panel> panelHistory = new List<Panel>();
    
    protected virtual void Start(){
        canvas = GetComponent<Canvas>();
        SetupPanels();
    }

    protected void SetupPanels(){
        Panel[] panels = GetComponentsInChildren<Panel>();
        foreach (Panel panel in panels){
            panel.Setup(this);
        }

        currentPanel.Show();
    }

    public void GoToPrevious(){
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

    protected void SetCurrent(Panel newPanel){
        currentPanel.Hide();
        currentPanel = newPanel;
        currentPanel.Show();
    }
}