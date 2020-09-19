using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

public class CheckForInputType : MonoBehaviour
{
    [SerializeField] private GameObject _PCInventory;
    [SerializeField] private GameObject _VRInventory;
    
    private void Start() {
        if (SteamVR.active) {
            Destroy(_PCInventory);
            return;
        }
        Destroy(_VRInventory);
    }
}
