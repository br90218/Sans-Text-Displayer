using UnityEngine;
using GoogleSheetsToUnity;


public class GoogleSheetsReader : MonoBehaviour
{

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

    private void GetDialogue()
    {
        SpreadsheetManager.ReadPublicSpreadsheet(new GSTU_Search(spreadSheetId, tabName), UpdateDialogue);
    }

    private void UpdateDialogue(GstuSpreadSheet callBack)
    {
        var itemCount = callBack.columns["text"].Count;
        var newDialogue = callBack.columns["text"][itemCount - 1].value;
        print(newDialogue);

        if (!_currentDialogueText.Equals(newDialogue))
        {
            _currentDialogueText = newDialogue;
            TextParser.UpdateText(_currentDialogueText);
        }
    }




}
