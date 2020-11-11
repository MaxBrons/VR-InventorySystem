using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string Name = "New Item";
    public Sprite Icon = null;

    public virtual void Use() {
        //Use Item
    }

    public IEnumerator ShowUsedText() {
        TextMeshProUGUI usedItemText = GameObject.FindGameObjectWithTag("UsedItemText").GetComponent<TextMeshProUGUI>();
        usedItemText.text = $"Used {Name}";
        yield return new WaitForSeconds(1f);
        usedItemText.text = string.Empty;
    }
}
