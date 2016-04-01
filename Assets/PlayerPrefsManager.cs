using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour {

	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_UNLOCK_KEY = "level_unlocked_";

	private static int maxDifficulty = 3;
	private static int minDifficulty = 1;

	public static void SetMasterVolume(float volume){
		if(volume >= 0f && volume <= 1f){
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		}else {
			Debug.LogError("Wrong Master Volume Range: " + volume);
		}
	}	

	public static float GetMasterVolume(){
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}

	public static void UnlockLevel(int level){
		if(level <= Application.levelCount-1){
			PlayerPrefs.SetInt(LEVEL_UNLOCK_KEY + level, 1);
		}else {
			Debug.LogError("Trying to Unlock Level not in BuildOrder");
		}
	}

	public static bool IsLevelUnlocked(int level){
		if(level >= Application.levelCount){
			Debug.LogError("Trying to query level not in build order");
			return false;
		}
		else {
			return PlayerPrefs.GetInt(LEVEL_UNLOCK_KEY + level) == 1;
		}
	}

	public static void SetDifficulty(int difficulty){
		if(difficulty >= 0 && difficulty <= maxDifficulty){
			PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
		} 
		else{
			Debug.LogError("Trying to set difficulty out of range");
		}
	}

	public static int GetDifficulty(){
		return PlayerPrefs.GetInt(DIFFICULTY_KEY);
	}

	public static int GetMaxDifficulty(){
		return maxDifficulty;
	}

	public static int GetMinDifficulty(){
		return minDifficulty;
	}
}
