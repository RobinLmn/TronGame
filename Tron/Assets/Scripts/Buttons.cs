using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    
    public void Local()
    {
       SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        SceneManager.LoadScene(2);
    }

    public void Play()
    {

    }
}
