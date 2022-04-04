using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class shelf : MonoBehaviour
{
    public LevelManager level;
    public Animator animator;
    public GameObject key;
    public Movement movement;
    
    void Start()
    {
        level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    private void OnMouseDown()
    {
        
        movement.onClicked += ShelfDisplay;
    }
    void ShelfDisplay()
    {
        Debug.Log("clicked");
        animator.SetBool("isOpen", true);
        movement.enabled=false;
    }
   
}
