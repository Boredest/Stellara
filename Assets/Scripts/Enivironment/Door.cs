using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] Animator transition;
    [SerializeField] private float transitionTime = 1.0f;

    private int diamondWinCount = 3;
    private bool levelOver = false;
    

    public void Interact()
    {
        
        if (UIManager.numOfDiamonds == diamondWinCount)
        {
            levelOver = true;
            if (levelOver)
            {
              Debug.Log("Loading next level.");
                //Go to next level
              StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
            }
           
            
           
        }
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);
    }
}
