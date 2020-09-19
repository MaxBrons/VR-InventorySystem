using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;
    [SerializeField] private Text _itemAmount;
    [SerializeField] private Button _itemButton;
    [SerializeField] private Button _removeButton;

    private Item _item;

    public void AddItem(Item item) {
        _item = item;
        if (_itemIcon) _itemIcon.sprite = item.Icon;
        if (_itemButton) _itemButton.enabled = true;

        if (_itemAmount) _itemAmount.enabled = true;
        if (_removeButton) _removeButton.interactable = true;
    }

    public void RemoveItem() {
        _item = null;
        if (_itemIcon) _itemIcon.sprite = null;
        if (_itemButton) _itemButton.enabled = false;

        if (_itemAmount) _itemAmount.enabled = false;
        if (_removeButton) _removeButton.interactable = false;
    }

    public void OnRemoveButtonPressed() {
        Inventory.Instance.Remove(_item);
    }

    public void UseItem() {
        if (_item != null) {
            _item.Use();
        }
    }
}
