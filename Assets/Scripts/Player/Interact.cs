using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteractable interaction = collision.GetComponent<IInteractable>();

        if (interaction != null)
        {
            interaction.Interact();
            
        }
    }
}
