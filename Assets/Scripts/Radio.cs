using UnityEngine;

public class Radio : Interactable
{
	[SerializeField] private AudioSource audioSource;
	private bool _radioIsOn;

	public override void Interact(Interactor interactor)
	{
		_radioIsOn = !_radioIsOn;
		audioSource.enabled = _radioIsOn;
	}
}