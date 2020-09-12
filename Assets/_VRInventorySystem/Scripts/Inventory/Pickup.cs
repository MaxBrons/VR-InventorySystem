using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour, IInteractable
{
    [SerializeField] private Item _item;
    public void Interact() {
        Debug.Log("You Picked Up: " + _item.Name);
        Inventory.Instance.Add(_item);
        Destroy(gameObject);
    }
}
