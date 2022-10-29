using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class JournalManager : MonoBehaviour
{

    //private static ... _journal; //all entries in the log

	[SerializeField] private TextMeshProUGUI title;
	[SerializeField] private TextMeshProUGUI testText;
	[SerializeField] private Image journalPanel;
	public static bool JournalPanelIsActive { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        //_journal = 
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.jKey.wasPressedThisFrame)
		{
			ToggleJournalPanel();
			return;
		}

		if (Keyboard.current.escapeKey.wasPressedThisFrame && JournalPanelIsActive||Keyboard.current.tabKey.wasPressedThisFrame && JournalPanelIsActive
		) ToggleJournalPanel();
    }
    //public static void AddALogEntry(...)
	//{
	//	
	//}

    //private string JournalToString()
	//{
	//	var res = "";
	//	foreach (var entry in _journal)
	//		res += entry+"\n";
	//	return res;
	//}

    private void ToggleJournalPanel()
    {
        JournalPanelIsActive = !JournalPanelIsActive;
		journalPanel.enabled = JournalPanelIsActive;
		title.enabled = JournalPanelIsActive;
		testText.enabled = JournalPanelIsActive;
        //testText.text = JournalToString();

    }
}
