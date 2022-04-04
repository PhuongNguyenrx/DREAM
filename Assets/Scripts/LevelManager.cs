using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public GameObject backgroundmid;
    public GameObject backgroundfront;
    public PlayerInput input;
    public int loopcount = 1;
    [SerializeField]
    EnemyAnimation enemy;
    [SerializeField] 
    private List<Sprite> 
    bgImage = new List<Sprite>();
    [SerializeField]
    private List<Sprite>
    bgImage2 = new List<Sprite>();
    public EnemyAnimation[] Enemies;
    public int key = 0;
    public static int keypart = 0;
    public TMP_Text looptext;
    public Animator clock;
  
    
    public int RandomValue;



    private void Start()
    {
        clock.SetTrigger("LoopReset");   
        looptext.text = "I";
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Sprite randomBG = bgImage[Random.Range(0, bgImage.Count)]; 
        backgroundmid.GetComponent<SpriteRenderer>().sprite = randomBG;
        Sprite randomBG2 = bgImage2[Random.Range(0, bgImage.Count)];
        backgroundfront.GetComponent<SpriteRenderer>().sprite = randomBG2;
        Enemies = new EnemyAnimation[enemies.Length];
        for (int i = 0; i < Enemies.Length; i++)
        {
            Enemies[i] = enemies[i].GetComponent<EnemyAnimation>();
            Enemies[i].AttackEnd += Restart;
        }
        //enemy.AttackEnd += GameOver;
     
       
    }
    // Update is called once per frame
   
    public void NextLoop()
    {
        if (key >= 2)
        {
            SceneManager.LoadScene("Checkpoint");
            
        }
        if (loopcount>=10 && key < 2)
        {
            SceneManager.LoadScene("GameOver");
        }
        loopcount++;
        looptext.text = loopcount.ToString();
        foreach (EnemyAnimation enemy in Enemies)
        {
            int random = Random.Range(0, 10);
            if (random > 7)
            {
                enemy.gameObject.SetActive(false);
            }
            else
            {
                enemy.gameObject.SetActive(true);
            };
            if (loopcount % 5 == 0)
            {
                Color tmp = enemy.gameObject.GetComponent<SpriteRenderer>().color;
                tmp.a -=0.2f;
                enemy.GetComponent<SpriteRenderer>().color = tmp;
            }
        }
        Sprite randomBG = bgImage[Random.Range(0, bgImage.Count)];
        backgroundmid.GetComponent<SpriteRenderer>().sprite = randomBG;
        Sprite randomBG2 = bgImage2[Random.Range(0, bgImage.Count)];
        backgroundfront.GetComponent<SpriteRenderer>().sprite = randomBG2;
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(0, -1.5f, 0);
    }
    
    void Restart()
    {
        SceneManager.LoadScene("SampleScene");
       

    }

    public void ObtainKey()
    {
        keypart += 1;
    }

    //public static string ToRoman(int number)
    //{
    //    number = loopcount;
    //    if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("Value must be between 1 and 3999");
    //    if (number < 1) return string.Empty;            
    //    if (number >= 1000) return "M" + ToRoman(number - 1000);
    //    if (number >= 900) return "CM" + ToRoman(number - 900); //EDIT: i've typed 400 instead 900
    //    if (number >= 500) return "D" + ToRoman(number - 500);
    //    if (number >= 400) return "CD" + ToRoman(number - 400);
    //    if (number >= 100) return "C" + ToRoman(number - 100);            
    //    if (number >= 90) return "XC" + ToRoman(number - 90);
    //    if (number >= 50) return "L" + ToRoman(number - 50);
    //    if (number >= 40) return "XL" + ToRoman(number - 40);
    //    if (number >= 10) return "X" + ToRoman(number - 10);
    //    if (number >= 9) return "IX" + ToRoman(number - 9);
    //    if (number >= 5) return "V" + ToRoman(number - 5);
    //    if (number >= 4) return "IV" + ToRoman(number - 4);
    //    if (number >= 1) return "I" + ToRoman(number - 1);
    //    loopcount = number;
    //    throw new ArgumentOutOfRangeException("Value must be between 1 and 3999");
        
    //}
}
