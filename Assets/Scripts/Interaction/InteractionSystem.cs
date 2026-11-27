using System;
using UnityEngine;

public interface IInteractable
{
    void Interact();
    void OnHover();
    void OnHoverExit();
}

public class InteractionSystem : MonoBehaviour
{
    public Camera cam;
    public float distance = 3f;
    public Color hoverColor = Color.green;

    private IInteractable current;
    private Renderer r;
    private Color originalColor;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, distance) && hit.collider.TryGetComponent(out IInteractable i))
        {
            if (current != i)
            {
                Clear();
                current = i;
                current.OnHover();

                r = hit.collider.GetComponent<Renderer>();
                if (r)
                {
                    ItemPickup pickup = hit.collider.GetComponent<ItemPickup>();
                    bool isBlocked = pickup != null && !Inventory.Instance.CanAdd(pickup.item);

                    originalColor = r.material.color;
                    r.material.color = isBlocked ? Color.red : Color.green;
                }
            }
            if (Input.GetKeyDown(KeyCode.E)) { current.Interact(); }
        }
        else
        {
            Clear();
        }
    }

    void Clear()
    {
        if (current != null) { current.OnHoverExit(); }
        if (r) { r.material.color = originalColor; }
        current = null;
        r = null;
    }
}
