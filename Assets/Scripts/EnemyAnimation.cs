using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Animator))]
public class EnemyAnimation : MonoBehaviour
{
    [SerializeField]
    private int questnumber;
    public float offset;
    public LevelManager level;
    Animator animator;
    public UnityAction AttackEnd;
    [SerializeField]
    private Movement movement;
    Rigidbody2D quest;
    public bool keytaken = false;
    [SerializeField]
    bool questkey = false;
    public UnityAction Attack;
    public UnityAction Quest;
    // Start is called before the first frame update
    void Start()
    {   
        level = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        animator = gameObject.GetComponent<Animator>();
        quest = this.GetComponentInChildren<Rigidbody2D>();
    }
    private void OnMouseDown() 
    {
        if (level.loopcount % questnumber==0 &&keytaken==false)
        {
            
            movement.onClicked += PlayQuestAnimation;
        }
        else if (level.loopcount %questnumber!=0)
        {
            
            movement.onClicked += PlayAttackAnimation;
        }
    }

    // Update is called once per frame

    void PlayAttackAnimation()
    {
        Attack?.Invoke();
        animator.SetBool("attack", true);
        
    }

    void PlayQuestAnimation()
    {
        Quest?.Invoke();
        animator.SetBool("quest", true);
        if (quest == null)
        {
            return;
        }
        
        keytaken = true;
        level.key+=1;
        quest.gravityScale = 1;
        quest.gameObject.transform.position = new Vector3(transform.position.x + offset, 1.5f, transform.position.z);
        if (questkey == true)
        {
            level.ObtainKey();
            questkey = false;
        }
        quest.GetComponent<SpriteRenderer>().sortingOrder = 4;
        
        quest.GetComponent<BoxCollider2D>().enabled = true;
        
    }

    public void LoadNewScene()
    {
        AttackEnd?.Invoke();
    }
}
