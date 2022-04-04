using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Guide : MonoBehaviour
{
    Transform player;
    public GameObject guidepanel;
    public Text guide;
    private string guidedisplay;
    public GameObject instructions;

    [TextArea(3,10) ]
    public string[] guides;
 
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        guidedisplay = guides[Random.Range(0, guides.Length)];
    }
    private void OnMouseOver()
    {
        guidepanel.SetActive(true);
        guide.text = guidedisplay;
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetMouseButtonDown(0))
        {
            
            instructions.SetActive(true);   
            /*EditorUtility.RevealInFinder(Application.dataPath+"/Keys/myNote.rar");*/
            
        }
        Time.timeScale = 0;

    }
    private void OnMouseExit()
    {
        Time.timeScale = 1;
        guidedisplay = guides[Random.Range(0, guides.Length)];
        guidepanel.SetActive(false);
        instructions.SetActive(false);
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x - 8f,player.position.y + 5f, player.position.z) ;
    }

}
