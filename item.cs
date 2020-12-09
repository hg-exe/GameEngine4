using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct InventoryItem
{
    public InventoryItem(string inName, Sprite inIcon, int inValue)
    {
        itemName = inName;
        icon = inIcon;
        value = inValue;
    }

    public string itemName;
    public Sprite icon;
    public int value;
}
public class Item : MonoBehaviour
{


    [SerializeField] string ItemName;
    [SerializeField] Sprite Icon;
    [SerializeField] int value;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if(player != null)
        {
            player.mySprites.Add(Icon);
            Destroy(gameObject);
        }
    }
}
