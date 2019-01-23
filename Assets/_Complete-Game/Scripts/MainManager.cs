using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour {

    public int score;
    public static IDictionary<string, int> difficulty = new Dictionary<string, int>();

    // Use this for initialization
    void Start () {

        difficulty["Easy"] = 3;
        difficulty["Hard"] = 20;


        changeScene("Menu");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void changeScene(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
