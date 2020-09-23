using UnityEngine;
using Valve.VR.Extras;

public class InteractableRaycaster : MonoBehaviour
{
    public static InteractableRaycaster Instance;

    private void Awake() {
        Instance = Instance ? Instance : this;
    }

    public void TryPickUpItem(Ray r) {
        Ray ray = r;
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction, Color.red, 20f, true);
        if (Physics.Raycast(ray, out hit)) {
            Transform selection = hit.transform;
            IInteractable selectionItem = selection.GetComponent<IInteractable>();
            if (selectionItem != null) {
                selectionItem.Interact();
            }
        }
    }
}
