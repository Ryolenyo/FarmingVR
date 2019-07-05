using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class ObjectiveList
{
	public int size = 3;
	
	public string[] description = new string[] {
		"Collect 10 golden products",
		"Sell 10 golden products in the first minute of the game",
		"Handle the mole without using trapper or net"
	};

	public ObjectiveType[] type = new ObjectiveType[] {
		ObjectiveType.Collecting,
		ObjectiveType.TimeLimit,
		ObjectiveType.Restriction
	};

	public string[][] requiredObject = new string[][] {
		new string[] {"Gold"},
		new string[] {"Gold"},
		new string[] {""}
	};

	public int[] requiredAmount = new int[] {
		10,
		10,
		0
	};

	public int[] time = new int[] {
		0,
		60,
		0
	};
}
