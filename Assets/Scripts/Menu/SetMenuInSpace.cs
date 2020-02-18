using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;
public class SetMenuInSpace : MonoBehaviour
{
    public SteamVR_LaserPointer steamVrLaserPointer;
    public SteamVR_Action_Boolean menuBtnAction;
    private Canvas canvas = null;
    public float distance = 1f;
    // Start is called before the first frame update
    void OnEnable()
    {
        canvas = GetComponent<Canvas>();
        menuBtnAction.AddOnStateDownListener(OnMenuBtnActionDown, SteamVR_Input_Sources.Any);

    }

    private void OnMenuBtnActionDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (canvas.enabled)
        {
            canvas.enabled = false;
            // transform.position = canvas.worldCamera.transform.position + canvas.worldCamera.transform.forward * distance;
        }
        else
        {
            canvas.enabled = true;
        }
        steamVrLaserPointer.pointer.SetActive(canvas.enabled);
    }
}
