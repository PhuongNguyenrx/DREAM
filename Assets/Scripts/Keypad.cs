using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Keypad : MonoBehaviour
{
    public Password[] numbers;


    private void OnMouseDown()
    {
        if (LevelManager.keypart == 2)
        {
            if (numbers[0].value == 0 && numbers[1].value == 2 && numbers[2].value == 1 && numbers[3].value == 1)
            {
                SceneManager.LoadScene("TrueEnd");
            }
            else
            {
                SceneManager.LoadScene("Delusional");
            }
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
