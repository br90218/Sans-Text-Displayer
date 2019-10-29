using UnityEngine;
using GoogleSheetsForUnity;

public class GoogleSheetsReader : MonoBehaviour
{
    [System.Serializable]
    public struct DialogueInfo
    {
        public string Timestamp;
        public string text;
    }



    public string spreadSheetId, tabName;
    public TextParser TextParser;

    private float timer;
    private string _currentDialogueText;

    // Start is called before the first frame update
    void Start()
    {
        _currentDialogueText = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 3f)
        {
            GetDialogue();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    private void OnEnable()
    {
        // Suscribe for catching cloud responses.
        Drive.responseCallback += HandleDriveResponse;
    }

    private void OnDisable()
    {
        // Remove listeners.
        Drive.responseCallback -= HandleDriveResponse;
    }




    // Processes the data received from the cloud.
    public void HandleDriveResponse(Drive.DataContainer dataContainer)
    {
        if (dataContainer.QueryType == Drive.QueryType.getTable)
        {
            string rawJSon = dataContainer.payload;
            //Debug.Log(rawJSon);
            // Check if the type is correct.
            if (string.Compare(dataContainer.objType, tabName) == 0)
            {
                // Parse from json to the desired object type.
                // PlayerInfo[] players = JsonHelper.ArrayFromJson<PlayerInfo>(rawJSon);
                DialogueInfo[] dialogueInfo = JsonHelper.ArrayFromJson<DialogueInfo>(rawJSon);
                print(dialogueInfo[dialogueInfo.Length - 1].text);

                var newDialogue = dialogueInfo[dialogueInfo.Length - 1].text;

                if (!_currentDialogueText.Equals(newDialogue))
                {
                    _currentDialogueText = newDialogue;
                    TextParser.UpdateText(_currentDialogueText);
                }
            }
        }
    }

    private void GetDialogue()
    {
        Drive.GetTable(tabName, true);
    }

}
