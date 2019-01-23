using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;


public class Provider
{
    public static string url = "https://awa-quizz.herokuapp.com/api/quizzes";
    //public static string url = "http://www.api.carboni.ch/quizzes";


    public Quizzes getGameQuizzesFromAPI()
    {
        string JSON_quizzes = CallHttpWebRequest(url);
        return JsonUtility.FromJson<Quizzes>(JSON_quizzes);
    }


    public Quizz getGameQuizzFromAPI(string quizzId)
    {
        string JSON_quizze = CallHttpWebRequest(url + "/" + quizzId);
        return JsonUtility.FromJson<Quizz>(JSON_quizze);
    }

    // Get all Data for api
    private string CallHttpWebRequest(string URL)
    {
        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(URL);
        req.Headers["quizz-token"] = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJ1c2VybmFtZSI6Imd1ZXN0IiwicGFzc3dvcmQiOiIkcGJrZGYyLXNoYTI1NiQyMDAwMCRjNjRWd3RnN0IuQThKeVJrN1AzL1h3JG9BRDloUnVEQTVkWVpKR1Y2cDNpdDBzYVFqdlFBemFZbi9wNW1kSGRDbDQifQ.P-KfTO8nq5oQNC_bIAY5VKOeNLyNbGE-gGrf0oIKQjc";
        req.Accept = "text/xml,text/plain,text/html,application/json";
        req.Method = "GET";
        HttpWebResponse result = (HttpWebResponse)req.GetResponse();
        Stream ReceiveStream = result.GetResponseStream();
        StreamReader reader = new StreamReader(ReceiveStream, System.Text.Encoding.UTF8);
        return reader.ReadToEnd();
    }
}
