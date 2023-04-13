using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadDynamicQuiz()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadStaticQuiz()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadInstructions()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadCompletionAPI()
    {
        SceneManager.LoadScene(4);
    }    
}
