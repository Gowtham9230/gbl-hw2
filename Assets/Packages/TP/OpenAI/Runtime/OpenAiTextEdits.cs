using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using SimpleJSON;

public class OpenAiTextEdits : MonoBehaviour
{
    private string apiKey = "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";
    private string orgKey = "org-WdUGLZ63fPT9tFmLmsYx0liA";

    // Set the endpoint URL for the API request
    private string endpointURL = "https://api.openai.com/v1/edits";

    void Start()
    {
        // Create a UnityWebRequest object with the endpoint URL
        UnityWebRequest editsRequest = UnityWebRequest.Get(endpointURL);

        // Set the header fields for the API request
        editsRequest.SetRequestHeader("X-Api-Key", apiKey);
        editsRequest.SetRequestHeader("X-Organization-Key", orgKey);

        // Send the API request and handle the response
        StartCoroutine(SendEditsRequest(editsRequest));
    }

    IEnumerator SendEditsRequest(UnityWebRequest request)
    {
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            Debug.Log("API request successful!");
            Debug.Log("Response: " + request.downloadHandler.text);
        }
        else
        {
            Debug.Log("API request failed!");
            Debug.Log("Error: " + request.error);
        }
    }
}


