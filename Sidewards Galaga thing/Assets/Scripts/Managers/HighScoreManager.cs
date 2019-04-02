using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class HighScoreManager : MonoBehaviour
{
	[Header("File I/O")]
	public string scoreFileName = "highscores.txt";
	public string DefaultName = "Unidentified player";
	public InputField NameField;
	public Text ScoreText;

	#region Xml
	public Scores LoadedScores = new Scores();
	public class Scores
	{
		public Scores()
		{
			for (int i = 0; i < scores.Length; i++)
			{
				scores[i] = -1;
			}
		}
		public string[] players = new string[10];
		public int[] scores = new int[10];

		public override string ToString()
		{
			string returnScores = string.Empty;
			for(int i = 0; i < players.Length && i < scores.Length; i++)
			{
				if((players[i] != null || players[i] != string.Empty) && scores[i] != -1)
					returnScores += players[i] + ":" + scores[i] + '\n';
			}
			return returnScores;
		}
	}

	public void SaveScores()
	{
		StreamWriter writer = new StreamWriter(Application.dataPath + "\\" + scoreFileName, false);
		writer.Write(JsonUtility.ToJson(LoadedScores));
		writer.Close();
	}

	public string GetScores()
	{
		string fileLocation = Application.dataPath + "\\" + scoreFileName;
		// If there's nothing there, then stahp. 
		if (!File.Exists(fileLocation)) return string.Empty;

		LoadedScores = JsonUtility.FromJson<Scores>(File.ReadAllText(fileLocation));
		// If it's invalid, stahp. 
		if (LoadedScores == null) return string.Empty;
		return LoadedScores.ToString();
	}

	private void AddScore(string newPlayer, int newScore)
	{
		// Find how high this score is placed. 
		int? desiredIndex = null;
		for (int i = 0; i < LoadedScores.scores.Length; i++)
		{
			if (LoadedScores.scores[i] == -1 || newScore < LoadedScores.scores[i])
			{
				desiredIndex = i;
				break;
			}
		}
		if (desiredIndex == null)
		{
			Debug.Log("Score of " + newScore +
			" not high enough for high scores list.", this);
			return;
		}
		// Then we move all of the scores back. 
		for (int i = LoadedScores.scores.Length - 1; i > desiredIndex; i--)
		{
			LoadedScores.players[i] = LoadedScores.players[i - 1];
			LoadedScores.scores[i] = LoadedScores.scores[i - 1];
		}
		// Insert new score in its place
		LoadedScores.players[(int)desiredIndex] = newPlayer;
		LoadedScores.scores[(int)desiredIndex] = newScore;
		Debug.Log("Score of " + newScore +
		" entered into high scores at position " + desiredIndex, this);

	}
	public void UpdateScores()
	{
		GetScores();
		if (NameField.text == string.Empty)
		{
			NameField.text = DefaultName;
		}
		AddScore(NameField.text, (int)MainManager.CurrentManager.timer);
		SaveScores();
	}

	public void ShowScores()
	{
		ScoreText.text = LoadedScores.ToString();
	}
	#endregion
}
