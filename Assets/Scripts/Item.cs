using UnityEngine;
using static InventoryManager;

public class Item : Interactable
{
	[SerializeField] private GameObject obj;
	[SerializeField] private string objName;

	public override void Interact(Interactor interactor)
	{
		TogglePrompt();
		ItemIsActive = false;
		obj.SetActive(ItemIsActive);
		AddItemToInventory(objName, 1);
	}
}