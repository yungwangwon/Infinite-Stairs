using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveData
{
    public int bestScore;
    public int coin;
	public SaveData(int bestScore =0, int coin=0) { this.bestScore = bestScore; this.coin = coin; }
}

public class LoadManager : MonoBehaviour
{
    string path;

	private void Start()
	{
		path = Path.Combine(Application.persistentDataPath, "DataBase.json");
		JsonLoad();
	}

	// JsonData 불러오기
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
				GameManager.instance.Load(saveData);
			}
		}
		else
		{
			Debug.Log("파일 존재x");
		}
	}

	// JsonData 저장
	public void JsonSave(SaveData savedata)
	{
		string jsonData = JsonUtility.ToJson(savedata);
		Debug.Log($"Save data: {jsonData}");
		File.WriteAllText(path, jsonData);
	}
}
