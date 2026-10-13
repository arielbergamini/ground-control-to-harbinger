using UnityEngine;

//item disappears in the game if we interact with it (pick it up)
public class DestroyableObject : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Destroy(gameObject);
    }

    public void OnHover ()
    {

    }

    public void OnHoverExit()
    {

    }
}
