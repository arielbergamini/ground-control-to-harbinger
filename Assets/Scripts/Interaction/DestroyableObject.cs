using UnityEngine;

//item disappears in the game if we interact with it (pick it up)
public class DestroyableObject : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Destroy(gameObject);
        //TODO -- we want to make this game object go to our inventory and be held as a global var.
    }

    public void OnHover ()
    {
        
    }

    public void OnHoverExit()
    {

    }
}
