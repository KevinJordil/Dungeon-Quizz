using System.Collections.Generic;

[System.Serializable]
public class Quizzes
{
    public List<Quizze> quizzes = new List<Quizze>();
}

[System.Serializable]
public class Quizze
{
    public string title;
    public string image;
    public string description;
    public QuizzeCreatedBy created_by;
    public int number_participants;
    public string id;
}

public class QuizzeCreatedBy
{
    public string id;
    public string username;
}
