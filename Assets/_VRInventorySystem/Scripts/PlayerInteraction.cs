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
        _input.Player.Pickup.performed += ctx => PickupItem();
        _input.Player.Pickup.Enable();
    }

    private void PickupItem() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            Transform selection = hit.transform;
            IInteractable selectionItem = selection.GetComponent<IInteractable>();
            if (selectionItem != null) {
                selectionItem.Interact();
            }
        }
    }
}
