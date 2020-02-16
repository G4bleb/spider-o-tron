using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class SetMenuInSpace : MonoBehaviour
{
    public SteamVR_Action_Boolean menuBtnAction;
    private Canvas canvas = null;
    public float distance = 1f;
    // Start is called before the first frame update
    void OnEnable()
    {
        canvas = GetComponent<Canvas>();
        menuBtnAction.AddOnStateDownListener(OnMenuBtnActionChange, SteamVR_Input_Sources.Any);

    }

    private void OnMenuBtnActionChange(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        canvas.enabled = true;
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.planeDistance = distance;
        canvas.renderMode = RenderMode.WorldSpace;
        // if (canvas.enabled)
        // {
        //     canvas.enabled = false;
        //     // transform.position = canvas.worldCamera.transform.position + canvas.worldCamera.transform.forward * distance;
        // }
        // else
        // {
        //     canvas.enabled = true;
        //     canvas.renderMode = RenderMode.ScreenSpaceCamera;
        //     canvas.renderMode = RenderMode.WorldSpace;
        // }
    }
}
