using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.Extras;

public class SteamVRInputController : MonoBehaviour
{
    [SerializeField] private GameObject source;
    [SerializeField] private SteamVR_Action_Boolean _pressedAButton;
    [SerializeField] private SteamVR_Action_Boolean _pressedJoystickButton;
    [SerializeField] private SteamVR_Input_Sources leftHand;
    [SerializeField] private SteamVR_Input_Sources rightHand;
    [SerializeField] private GameObject _inventoryUI;

    void Start() {
        _pressedAButton.AddOnStateDownListener(ADown, rightHand);
        _pressedJoystickButton.AddOnStateDownListener(JoyStickDown, leftHand);
    }

    public void ADown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource) {
        InteractableRaycaster.Instance.TryPickUpItem(new Ray(source.transform.position, source.transform.forward));
    }
    public void JoyStickDown(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource) {
        _inventoryUI.SetActive(!_inventoryUI.activeSelf);
    }
}
