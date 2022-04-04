using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItem : MonoBehaviour
{
    [SerializeField]
    Transform parent;
    public GameObject key;
    bool isOpen = false;
    private void Start()
    {
        parent = GameObject.FindGameObjectWithTag("Player").transform;    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)&&isOpen==false)
        {
            key.SetActive(true);
            StartCoroutine(wait());
            
        }

        
        
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.2f);
        isOpen = true;

    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isOpen == true)
        {
            if (parent.localScale.x < 0)
            {
                key.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            StopAllCoroutines();
            key.SetActive(false);
            gameObject.SetActive(false);
        };
    }
}
