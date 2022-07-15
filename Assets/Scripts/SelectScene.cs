using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectScene : MonoBehaviour
{
    public void sceneSelect()
    {
        switch (this.gameObject.name)
        {
            case "Problem 1":
                SceneManager.LoadScene("Problem-1");
                break;
            case "Problem 2":
                SceneManager.LoadScene("Problem-2");
                break;
            case "Problem 3":
                SceneManager.LoadScene("Problem-3");
                break;
            case "Problem 4":
                SceneManager.LoadScene("Problem-4");
                break;
            case "Problem 5":
                SceneManager.LoadScene("Problem-5");
                break;
            case "Problem 6":
                SceneManager.LoadScene("Problem-6");
                break;
            case "Problem 7":
                SceneManager.LoadScene("Problem-7");
                break;
            case "Problem 8":
                SceneManager.LoadScene("Problem-8");
                break;
            case "Problem 9":
                SceneManager.LoadScene("Problem-9");
                break;
            case "Menu":
                SceneManager.LoadScene("Problem-10");
                break;
        }
    }
}
