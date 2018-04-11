using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MakeScriptableObject {
	[MenuItem("CustomAssets/Job")]
	public static void CreateJobAsset(){
		Job database = ScriptableObject.CreateInstance<Job> ();
		AssetDatabase.CreateAsset (database, "Assets/Jobs/Job #.asset");
		AssetDatabase.SaveAssets ();
	}

	[MenuItem("CustomAssets/Recruit")]
	public static void CreateRecruitAsset(){
		Recruit database = ScriptableObject.CreateInstance<Recruit> ();
		AssetDatabase.CreateAsset (database, "Assets/Recruits/Recruit #.asset");
		AssetDatabase.SaveAssets ();
	}

	[MenuItem("CustomAssets/AllRecruits")]
	public static void CreateAllRecruitsAsset(){
		AllRecruits database = ScriptableObject.CreateInstance<AllRecruits> ();
		AssetDatabase.CreateAsset (database, "Assets/Recruits/AllRecruits #.asset");
		AssetDatabase.SaveAssets ();
	}

	/*
	[MenuItem("CustomAssets/Upgrade")]
	public static void CreateUpgradeAsset(){
		Upgrade database = ScriptableObject.CreateInstance<Upgrade> ();
		AssetDatabase.CreateAsset (database, "Assets/Upgrades/Upgrade #.asset");
		AssetDatabase.SaveAssets ();
	}
	*/
}