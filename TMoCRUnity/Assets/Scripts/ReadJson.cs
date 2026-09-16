using UnityEngine;

public class ReadJson : MonoBehaviour
{
    [SerializeField] private TextAsset jsonFilePages;
    [SerializeField] private TextAsset jsonFileChoices;
    private static Choices jsonChoices;
    private static Pages jsonPages;
    public static Choices JsonChoices
    {
        get { return jsonChoices; }
    }
    private void Awake()
    {
        jsonPages = JsonUtility.FromJson<Pages>(jsonFilePages.text);
        jsonChoices = JsonUtility.FromJson<Choices>(jsonFileChoices.text);
        foreach(Choice choice in jsonChoices.choices)
        {
            Debug.Log(choice.choiceCount + ": " + choice.choiceA + " " +  choice.choiceB);
        } 
        foreach (Page page in jsonPages.pages)
        {
            for (int i = 0; i < page.dialogue.Length; i++)
            {
                Debug.Log(page.personSpeaking[i] + ": " +  page.dialogue[i]);
            }
        }
    }
}
