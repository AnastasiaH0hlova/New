using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Note : Interactable
{
	private static bool _noteImageIsEnabled;
	[SerializeField] private GameObject noteObj;
	[SerializeField] private Image noteImage;

	private void Update()
	{
		if (Keyboard.current.escapeKey.wasPressedThisFrame && _noteImageIsEnabled
		|| Keyboard.current.tabKey.wasPressedThisFrame && _noteImageIsEnabled
	    ||Keyboard.current.jKey.wasPressedThisFrame && _noteImageIsEnabled) ToggleNoteImage();
	}

	public override void Interact(Interactor interactor)
	{
		TogglePrompt();
		ItemIsActive = false;
		noteObj.SetActive(ItemIsActive);
		ToggleNoteImage();
	}

	private void ToggleNoteImage()
	{
		_noteImageIsEnabled = !_noteImageIsEnabled;
		noteImage.enabled = _noteImageIsEnabled;
	}
}