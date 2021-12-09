using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    new public string name = "new item";
    public Sprite icon = null;

    public virtual void Use()
    {
        //kalo pake ngapain tiap item
        
        Debug.Log("Using "+name);
        Debug.Log("Darah Player bertambah sebanyak: 50 ");
    }


    public void RemoveFromInventory()
    {
        Inventory.instance.Remove(this);
    }
}
