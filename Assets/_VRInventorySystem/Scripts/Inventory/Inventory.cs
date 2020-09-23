using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public event Action OnInventoryChange;
    public List<Item> Items { get; private set; } = new List<Item>();

    [SerializeField] private int _amountOfSlots = 6;
    private Text IventoryItemText;

    private void Awake() {
        Instance = this;
    }

    public void Add(Item item) {
        if(Items.Count >= _amountOfSlots) {
            print("Not Enough Room");
            return;
        }
        Items.Add(item);
        OnInventoryChange?.Invoke();
    }

    public void Remove(Item item) {
        if (Items.Contains(item)) {
            Items.Remove(item);
            print("Removed the item");
        }
        OnInventoryChange?.Invoke();
        Debug.Log(item.Name);
    }

    public void SetInvItemText(string content) => IventoryItemText.text = content;
    public string GetInvItemText() {
        return IventoryItemText.text;
    }
}
