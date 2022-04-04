using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Password : MonoBehaviour
{
    public int value = 0;
   
    public SpriteRenderer renderer;
    [SerializeField]
    private List<Sprite>
    numbers = new List<Sprite>();
    private void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {   if (value == 9)
        {
            value = 0;
            renderer.sprite = numbers[value];
            return;
        }
        value++;
        renderer.sprite = numbers[value];
    }
}
