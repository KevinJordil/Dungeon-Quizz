using System.Collections.Generic;

[System.Serializable]
public class Quizz
{
    public string id;
    public string title;
    public string description;
    public string created_by;
    public int number_participants;
    public List<Question> questions;
}