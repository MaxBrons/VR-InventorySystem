using UnityEngine;
using System.Collections;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Transform _parent;
    [SerializeField] private GameObject _inventoryUI;

    private PlayerInput _input;
    private InventorySlot[] _slots;

    private void Awake() {
        if (_input == null) {
            _input = new PlayerInput();
        }
    }

    private void Start() {
        _input.UI.Open.performed += ctx => _inventoryUI.SetActive(!_inventoryUI.activeSelf);
        _input.UI.Open.Enable();

        _inventory = Inventory.Instance;
        _inventory.OnInventoryChange += UpdateUI;

        _slots = _parent.GetComponentsInChildren<InventorySlot>();
        UpdateUI();
    }

    private void UpdateUI() {
        for (int i = 0; i < _slots.Length; i++) {
            if (i < _inventory.Items.Count) {
                _slots[i].AddItem(_inventory.Items[i]);
                continue;
            }
            _slots[i].RemoveItem();
        }
    }
}
