using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private PlayerInput _input;

    private void Awake() {
        if (_input == null) {
            _input = new PlayerInput();
        }
    }

    private void Start() {
        _input.Player.Pickup.performed += ctx => 
            InteractableRaycaster.Instance.TryPickUpItem(cam.ScreenPointToRay(Input.mousePosition + cam.transform.forward));
        _input.Player.Pickup.Enable();
    }
}
