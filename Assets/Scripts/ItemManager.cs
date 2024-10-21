using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    private Item currentItem;

    private void Awake()
    {
        Instance = this;
    }

    public void PickUpItem(Item item)
    {
        if (currentItem != null)
        {
            return;
        }

        currentItem = item;
        item.gameObject.SetActive(false);
        PlaceItemInHand(item);
    }

    private void PlaceItemInHand(Item item)
    {
        Vector3 originalScale = item.transform.localScale;

        item.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2;

        item.transform.SetParent(Camera.main.transform);

        item.transform.localScale = originalScale;

    }



    public void DropItem()
    {
        if (currentItem == null)
        {
            return;
        }

        currentItem.gameObject.SetActive(true);
        currentItem.transform.SetParent(null);
        currentItem.transform.position = Camera.main.transform.position + Camera.main.transform.forward * 3;
        currentItem = null;
    }

}
