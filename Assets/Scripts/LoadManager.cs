using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData
{
    public int bestScore;
    public int coin;
}

public class LoadManager : MonoBehaviour
{
    string path;

	private void Awake()
	{
		path = Path.Combine(Application.persistentDataPath, "DataBase.json");
		JsonLoad();
	}

	void JsonLoad()
	{
		SaveData saveData = new SaveData();

		// 파일이 있으면
		if(File.Exists(path))
		{
			string loadJson = File.ReadAllText(path);
			saveData = JsonUtility.FromJson<SaveData>(loadJson);

			if(saveData != null)
			{
				GameManager.instance.bestScore = saveData.bestScore;
				GameManager.instance.money = saveData.coin;
			}
		}
		else
		{
			Debug.Log("파일 존재x");
		}
	}
}
