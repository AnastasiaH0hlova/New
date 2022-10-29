using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
	private static Dictionary<string, int> _inventory;
	[SerializeField] private TextMeshProUGUI testText;
	[SerializeField] private Image inventoryPanel;
	public static bool InventoryPanelIsActive { get; private set; }

	private void Start()
	{
		_inventory = new Dictionary<string, int>
		{
			{ "Flashlight", 0 },
			{ "Medicines", 0 },
			{ "Compass", 0 }
			// { "", 0 }
		};
	}

	private void Update()
	{
		if (Keyboard.current.tabKey.wasPressedThisFrame)
		{
			ToggleInventoryPanel();
			return;
		}

		if (Keyboard.current.escapeKey.wasPressedThisFrame && InventoryPanelIsActive||Keyboard.current.jKey.wasPressedThisFrame && InventoryPanelIsActive) ToggleInventoryPanel();
	}

	public static void AddItemToInventory(string objName, int quantity)
	{
		_inventory[objName] += quantity;
	}

	private string InventoryDictToString()
	{
		var res = "";
		foreach (var entry in _inventory)
			res += entry.Key + entry.Value + "\n";
		return res;
	}

	private void ToggleInventoryPanel()
	{
		InventoryPanelIsActive = !InventoryPanelIsActive;
		inventoryPanel.enabled = InventoryPanelIsActive;
		testText.enabled = InventoryPanelIsActive;
		testText.text = InventoryDictToString();
	}
}