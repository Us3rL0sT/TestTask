using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;

    public void OnMouseDown()
    {
        ItemManager.Instance.PickUpItem(this);
    }
}
