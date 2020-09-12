using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image _background;
    [SerializeField] private Image _itemIcon;
    [SerializeField] private Text _itemAmount;
    [SerializeField] private Button _itemButton;
    [SerializeField] private Button _removeButton;

    private Item _item;

    public void AddItem(Item item) {
        _item = item;
        _itemIcon.sprite = item.Icon;
        _itemButton.enabled = true;

        _itemAmount.enabled = true;
        _removeButton.interactable = true;
    }

    public void RemoveItem() {
        _item = null;
        _itemIcon.sprite = null;
        _itemButton.enabled = false;

        _itemAmount.enabled = false;
        _removeButton.interactable = false;
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
