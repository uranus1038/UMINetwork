using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterData : MonoBehaviour
{
	public static CharacterData current;
	public static CharacterData cDat01;
	public static CharacterData cDat02;
	public static CharacterData cDat03;
	public string Name;
	public int lv;
	private void Awake()
    {
		current = this;
		cDat01 = this;
		cDat02 = this;
		cDat03 = this;
    }
    public void CharacterInit(int nSlot)
    {
		this.Name = umiCharacterData.cDat.nName[nSlot];
		this.lv = 1;
    }
	public static int[] getNewRandomStat(string mType)
	{
		int[] typeStat = CharacterData.getTypeStat(mType);
		for (int i = 0; i < 4; i++)
		{
			int num = UnityEngine.Random.Range(0, 8);
			typeStat[num]++;
		}
		for (int j = 0; j < 4; j++)
		{
			int num2 = UnityEngine.Random.Range(0, 8);
			typeStat[num2]--;
		}
		for (int k = 0; k <= 7; k++)
		{
			typeStat[k] = Mathf.Clamp(typeStat[k] + 1, 3, 12);
		}
		return typeStat;
	}
	public static int[] getTypeStat(string mType)
	{
		int[] result;
		if (mType == "Wolf")
		{
			result = new int[]
			{
			7,
			8,
			7,
			7,
			6,
			5,
			5,
			3
			};
		}
		else if (mType == "Bison")
		{
			result = new int[]
			{
			9,
			8,
			6,
			8,
			4,
			4,
			5,
			4
			};
		}
		else if (mType == "Panda")
		{
			result = new int[]
			{
			8,
			7,
			8,
			6,
			4,
			4,
			6,
			5
			};
		}
		else if (mType == "Whale")
		{
			result = new int[]
			{
			5,
			9,
			3,
			9,
			7,
			7,
			4,
			4
			};
		}
		else if (mType == "Cat")
		{
			result = new int[]
			{
			8,
			4,
			9,
			5,
			3,
			4,
			6,
			9
			};
		}
		else if (mType == "Chameleon")
		{
			result = new int[]
			{
			7,
			5,
			8,
			5,
			4,
			5,
			7,
			7
			};
		}
		else if (mType == "Rabbit")
		{
			result = new int[]
			{
			6,
			4,
			7,
			7,
			5,
			6,
			5,
			8
			};
		}
		else if (mType == "Mole")
		{
			result = new int[]
			{
			5,
			7,
			5,
			6,
			5,
			5,
			8,
			7
			};
		}
		else if (mType == "Monkey")
		{
			result = new int[]
			{
			5,
			5,
			4,
			8,
			8,
			8,
			6,
			5
			};
		}
		else if (mType == "Sheep")
		{
			result = new int[]
			{
			4,
			5,
			4,
			4,
			8,
			8,
			8,
			4
			};
		}
		else if (mType == "Penguin")
		{
			result = new int[]
			{
			3,
			6,
			5,
			3,
			9,
			7,
			9,
			6
			};
		}
		else if (mType == "Bat")
		{
			result = new int[]
			{
			6,
			5,
			6,
			5,
			7,
			9,
			4,
			6
			};
		}
		else
		{
			result = new int[8];
		}
		return result;
	}
}
