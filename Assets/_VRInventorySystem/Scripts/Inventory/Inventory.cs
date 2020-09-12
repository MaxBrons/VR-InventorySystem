using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;
    public event Action OnInventoryChange;
    public List<Item> Items { get; private set; } = new List<Item>();
    [SerializeField] private int _amountOfSlots = 6;

    private void Awake() {
        Instance = Instance ? Instance : this;
    }

    public void Add(Item item) {
        if(Items.Count >= _amountOfSlots) {
            print("Not Enough Room");
            Instantiate(item);
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
    }
}
