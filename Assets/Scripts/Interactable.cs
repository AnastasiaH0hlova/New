using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
	[SerializeField] private GameObject promptLabel;

	public bool PromptIsActive { get; private set; } = true;
	public bool ItemIsActive { get; protected set; } = true;

	private void Start()
	{
		TogglePrompt();
	}

	public abstract void Interact(Interactor interactor);

	public void TogglePrompt()
	{
		PromptIsActive = !PromptIsActive;
		promptLabel.SetActive(PromptIsActive);
	}
}