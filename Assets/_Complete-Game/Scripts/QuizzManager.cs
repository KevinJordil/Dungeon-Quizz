using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class QuizzManager : MonoBehaviour
{

    private Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private TextMeshProUGUI questionText;

    [SerializeField]
    private List<TextMeshProUGUI> answerText;

    [SerializeField]
    private List<Button> buttons;

    [SerializeField]
    private List<Image> wrongImages;

    [SerializeField]
    private List<Image> rightImages;

    public Quizz quizz;
    private Color transparent;



    // Use this for initialization
    void Start()
    {
        hideImages();
        quizz = MenuManager.currentQuizz;

        transparent[3] = 0;

        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = quizz.questions.ToList<Question>();
        }

        SetCurrentQuestion();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void hideImages()
    {
        foreach (Image wrongImage in wrongImages)
        {
            wrongImage.enabled = false;
        }
        foreach (Image rightImage in rightImages)
        {
            rightImage.enabled = false;
        }
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        questionText.text = currentQuestion.question;

        for (int i = 0; i < answerText.Count; i++)
        {
            if (i < currentQuestion.answers.Count)
            {
                answerText[i].text = currentQuestion.answers[i].name;
                buttons[i].enabled = true;
            }
            else
            {
                answerText[i].text = "Vide";
                buttons[i].enabled = false;
                answerText[i].color = transparent;
            }

        }

        unansweredQuestions.Remove(currentQuestion);
    }

    public void UserSelectResponse(int answerIndex)
    {
        if (currentQuestion.answers[answerIndex].value)
        {
            Completed.GameManager.level = MainManager.difficulty["Easy"];
            rightImages[answerIndex].enabled = true;
        }
        else
        {
            Completed.GameManager.level = MainManager.difficulty["Hard"];
            wrongImages[answerIndex].enabled = true;
            for (int i = 0; i < currentQuestion.answers.Count; i++)
            {
                if (currentQuestion.answers[i].value)
                {
                    rightImages[i].enabled = true;
                    break;
                }
            }
        }
        StartCoroutine(waitChangeScene(2, ("Game")));

    }

    public static IEnumerator waitChangeScene(int sec, string scene)
    {
        yield return new WaitForSeconds(sec);
        MainManager.changeScene(scene);
    }







}
