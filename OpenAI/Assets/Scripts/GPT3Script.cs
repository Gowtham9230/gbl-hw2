using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class GPT3Script : MonoBehaviour
{
    public string apiKey = "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";
    public Text textmesh;
    public InputField Input, command;

    // The engine you want to use (keep in mind that it has to be the exact name of the engine)
    private string model = "text-davinci-edit-001";
    private string instruction = "Fix the spelling mistakes";
    private string inputText = "What day of the wek is it?";

    public void GetResponse()
    {
        StartCoroutine(MakeRequest());
    }

    IEnumerator MakeRequest()
    {
        // Create a JSON object with the necessary parameters
        var json = "{\"model\":\"" + model + "\",\"instruction\":\"" + command.text + "\",\"input\":\"" + Input.text + "\"}";
        byte[] body = System.Text.Encoding.UTF8.GetBytes(json);

        // Create a new UnityWebRequest
        var request = new UnityWebRequest("https://api.openai.com/v1/edits", "POST");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(body);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + apiKey);

        // Send the request
        yield return request.SendWebRequest();

        // Check for errors
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            var response = JsonUtility.FromJson<Response>(request.downloadHandler.text);
            Debug.Log(response.choices[0].text.TrimStart().TrimEnd());

            textmesh.text = response.choices[0].text.TrimStart().TrimEnd().ToString();

        }
    }

    [System.Serializable]
    private class Response
    {
        public Choice[] choices;
    }

    [System.Serializable]
    private class Choice
    {
        public string text;
    }

}
