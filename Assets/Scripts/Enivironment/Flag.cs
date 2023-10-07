using UnityEngine;

public class Flag : MonoBehaviour, IInteractable
{
    private bool isTriggered = false;
    private float speed = 3.5f;

    [SerializeField] Transform endPoint;
    
    public void Interact()
    {
        isTriggered = true; 
    }
  
    
    void Update()
    {
        if (isTriggered && transform.position != endPoint.position)
        {
            Vector3 direction = endPoint.position;
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position,
                speed * Time.deltaTime);
                 
        }

       
        
    }

  
}
