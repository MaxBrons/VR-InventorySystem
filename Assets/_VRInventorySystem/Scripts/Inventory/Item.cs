using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string Name = "New Item";
    public Sprite Icon = null;

    public virtual void Use() {
        //Use the Item
        Debug.Log("Item Used");
        Inventory.Instance.Remove(this);
    }
}
