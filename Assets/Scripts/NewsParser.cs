using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class NewsParser
{
    private static string jsonDirectoryPath = Path.Combine(Application.streamingAssetsPath, "News templates");

    public static IEnumerable<NewsTemplate> GetTemplates()
    {
        foreach(var jsonPath in Directory.GetFiles(jsonDirectoryPath, "*.json"))
        {
            var json = File.ReadAllText(jsonPath);
            var template = JsonUtility.FromJson<NewsTemplate>(json);
            Debug.Log(json);
            Debug.Log(template.TitleTemplate);
            yield return template;
        }
        yield break;
    }
}