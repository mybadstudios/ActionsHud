using UnityEngine;

public class SampleInteractions : MonoBehaviour {

	public string dialogue_file_name;
	public int dialogue_turn_to_speak;

	public void StartDialogue()
	{
		print (string.Format("I am going to speak turn {0} of file {1}", dialogue_turn_to_speak, dialogue_file_name));
	}

	public void Inspect()
	{
		print ("This Inspect function is called on all the robots");
	}

	public void Collect()
	{
		print ("You are not allowed to collect this robot. It is a public servant");
	}

}
