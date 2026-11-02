using UnityEngine;

//item disappears in the game if we interact with it (pick it up)

public class ItemPickup : MonoBehaviour, IInteractable
{
    public Item item;


    void Start()
    {
        if (item == null)
        {
            Debug.LogError("Item not found");
        }
    }

    public void Interact()
    {
        if (item == null)
        {
            Debug.LogError("Item not found: " + gameObject.name);
            return;
        }
        if (Inventory.Instance.AddItem(item))
        {
            Destroy(gameObject);
        }
    }

    public void OnHover()
    {

    }

    public void OnHoverExit()
    {

    }
}