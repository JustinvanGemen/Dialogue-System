using UnityEngine;

namespace _Scripts
{
	[System.Serializable]
	public class Dialogue {

		public string Name;

		[TextArea(3, 10)]
		public string[] Sentences;

	}
}