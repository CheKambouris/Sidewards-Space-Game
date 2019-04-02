using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{

	[Header("Events")]
	public UnityEvent playerDeathEvents;

	public static MainManager CurrentManager;
	[HideInInspector]public float timer = 0f;

	private void Start()
	{
		CurrentManager = this;
	}

	public void Kill(GameObject gameObject)
	{
		if (gameObject.tag == "Player")
		{
			playerDeathEvents.Invoke();
			return;
		}
		Destroy(gameObject);
	}
	public void DestroyChildren()
	{
		for(int i = 0;  i < transform.childCount; i++)
		{
			Destroy(transform.GetChild(i).gameObject);
		}
	}
	public void StartTimer()
	{
		StartCoroutine(DoTimer());
	}
	public void StopTimer()
	{
		StopCoroutine(DoTimer());
	}
	private IEnumerator DoTimer()
	{
		while (true)
		{
			yield return new WaitForEndOfFrame();
			timer += Time.deltaTime;
		}
	}
	public void Reload()
	{
		SceneManager.LoadScene(0);
	}
}
	#region File I/O
	//public void UpdateScores()
	//{
	//	LoadScoresFromFile();
	//	if (NameField.text == string.Empty)
	//	{
	//		NameField.text = DefaultName;
	//	}
	//	AddScore(NameField.text, (int)timer);
	//	SaveScoresToFile();
	//}
	//public void ShowScores()
	//{
	//	if(GetComponent<HighScoreManager>().LoadedScores != null)
	//	ScoreText.text = GetComponent<HighScoreManager>().LoadedScores.ToString();
	//}
	//[Header("File I/O")]
	//internal string[] players = new string[10];
	//internal int?[] scores = new int?[10];
	//public string scoreFileName = "highscores.txt";
	//public string DefaultName = "Unidentified player";
	//public InputField NameField;
	//public Text ScoreText;
	//private void LoadScoresFromFile()
	//{
	//	string filePath = Application.dataPath + "\\" + scoreFileName;
	//	// Check existence of file, if it doesn't exist return.  
	//	if (!File.Exists(filePath))	return;
	//	// Refresh scores. 
	//	scores = new int?[scores.Length];
	//	// Create new input stream. 
	//	StreamReader fileReader = new StreamReader(filePath);
	//	for(int i = 0; fileReader.Peek() != 0 && i < scores.Length; i++)
	//	{
	//		string fileLine = fileReader.ReadLine();
	//		Regex scorePattern = new Regex(@"([a-zA-Z]+):([0-9]+)");
	//		if (!scorePattern.IsMatch(fileLine))
	//		{
	//			Debug.LogError("Invalid line in scores file at " + i +
	//		   ", using default value.", this);
	//			scores[i] = null;
	//			players[i] = null;
	//			return;
	//		}
	//		// Create score field. 
	//		string player = Regex.Match(fileLine, scorePattern.GroupNameFromNumber(0)).Value;
	//		players[i] = player;
	//		string score = Regex.Match(fileLine, scorePattern.GroupNameFromNumber(1)).Value;
	//		scores[i] = int.Parse(score);
	//	}
	//	fileReader.Close();
	//}
	//private void SaveScoresToFile()
	//{
	//	// Create new output stream
	//	StreamWriter fileWriter = new StreamWriter(Application.dataPath + "\\"
	//   + scoreFileName);
	//	// Write the lines to the file
	//	for (int i = 0; i < scores.Length; i++)
	//	{
	//		if(players[i] != string.Empty || scores[i] == null)
	//		fileWriter.WriteLine(players[i] + ":" + scores[i]);
	//	}
	//	// Close the stream
	//	fileWriter.Close();
	//	// Write a log message.
	//	Debug.Log("High scores written to " + scoreFileName);
	//}

	//private void AddScore(string newPlayer, int newScore)
	//{
	//	// Find how high this score is placed. 
	//	int? desiredIndex = null;
	//	for (int i = 0; i < scores.Length; i++)
	//	{
	//		if (scores[i] == null || newScore < scores[i])
	//		{
	//			desiredIndex = i;
	//			break;
	//		}
	//	}
	//	if (desiredIndex == null)
	//	{
	//		Debug.Log("Score of " + newScore +
	//		" not high enough for high scores list.", this);
	//		return;
	//	}
	//	// Then we move all of the scores back. 
	//	for (int i = scores.Length - 1; i > desiredIndex; i--)
	//	{
	//		players[i] = players[i - 1];
	//		scores[i] = scores[i - 1];
	//	}
	//	// Insert new score in its place
	//	players[(int)desiredIndex] = newPlayer;
	//	scores[(int)desiredIndex] = newScore;
	//	Debug.Log("Score of " + newScore +
	//	" entered into high scores at position " + desiredIndex, this);

	//}
	#endregion
