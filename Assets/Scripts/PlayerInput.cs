using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class PlayerInput : MonoBehaviour
{   [SerializeField]
    Movement movement;
    public Vector2 mousePos;
    public UnityAction onClicked;
    public TMP_Text gameovertext;
    

    // Update is called once per frame
    public void Update()
    {   
        if (Input.GetMouseButtonDown(0))
        {
            if (gameovertext != null)
            {
                gameovertext.enabled = false;
            }
            
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject.tag=="Enemy")
            {

                movement.Move(hit.collider.transform.position.x+hit.collider.GetComponent<EnemyAnimation>().offset);
                movement.clicked = true;
                return;
            };
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            movement.Move(mousePos.x);
        }
    }
}
