using System.Collections;
using System.Collections.Generic;
using Valve.VR;
using UnityEngine;

public class CheckForInputType : MonoBehaviour
{
    [SerializeField] private GameObject _PCInventory;
    [SerializeField] private GameObject _VRInventory;
    [SerializeField] private GameObject _player;
    [SerializeField] private Camera _normalCam;
    
    private void Start() {
        if (SteamVR.active) {
            _player.SetActive(true);
            _normalCam.gameObject.SetActive(false);
            Destroy(_PCInventory);
            return;
        }
        _player.SetActive(false);
        _normalCam.gameObject.SetActive(true);
        Destroy(_VRInventory.gameObject);
    }
}
