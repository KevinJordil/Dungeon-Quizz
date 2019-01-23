using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    [SerializeField]
    public Button prefab;

    [SerializeField]
    public Image scrollContent;

    public Quizzes quizzes;
    public List<Quizz> quizzs;
    public static Quizz currentQuizz;



    // Use this for initialization
    void Start () {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.Log("Error. Check internet connection!");
        }


        Provider provider = new Provider();

        quizzes = provider.getGameQuizzesFromAPI();
        foreach(Quizze quizze in quizzes.quizzes)
        {
            quizzs.Add(provider.getGameQuizzFromAPI(quizze.id));
            Button cloneButton = Instantiate(prefab, scrollContent.transform);
            cloneButton.GetComponentInChildren<TextMeshProUGUI>().text = quizze.title;
            cloneButton.onClick.AddListener(() => buttonClick(quizzes.quizzes.IndexOf(quizze)));
        }




    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void press(int id)
    {
        currentQuizz = quizzs[0];
        changeScene("Quizz");
    }

    public void changeScene(string scene)
    {
        MainManager.changeScene(scene);
    }

    public void buttonClick(int id)
    {
        currentQuizz = quizzs[id];
        changeScene("Quizz");
    }
}
