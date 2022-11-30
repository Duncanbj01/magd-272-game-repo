using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameManager : MonoBehaviour
{
    //singleton pattern
    //Instance variable
    static GameManager instance;
    [SerializeField] int coinCollected = 0; 

    private void Awake()
    {
        //see if its null
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            //destory self if not null
            Destroy(gameObject); 
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            LoadScene("Secondscene"); 
        }
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene); 
    }


    
}
