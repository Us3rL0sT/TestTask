using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Item item = hit.collider.GetComponent<Item>();
                if (item != null)
                {
                    item.OnMouseDown();
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (ItemManager.Instance != null)
            {
                ItemManager.Instance.DropItem();
            }
        }
    }
}
