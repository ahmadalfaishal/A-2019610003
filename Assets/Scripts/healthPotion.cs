using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/HP-Potion")]
public class healthPotion : Item
{
    public float healingAmount;
    
    public override void Use()
    {
        base.Use();
        //tambah darah
        float currHealth = PlayerPrefs.GetFloat("darah_player");
        currHealth += healingAmount;
        PlayerPrefs.SetFloat("darah_player",currHealth);
        
        //kurangin dari inventory
        RemoveFromInventory();
    }
}
