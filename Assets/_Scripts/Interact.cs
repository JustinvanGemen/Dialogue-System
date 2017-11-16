using UnityEngine;

namespace _Scripts
{
	public class Interact : MonoBehaviour
	{

		private PlayerMovement _playerMovement;
		private DialogueStarter _dialogueStarter;
		[SerializeField]private DialogueManager _dialogueManager;

		private void Start()
		{
			_playerMovement = GetComponent<PlayerMovement>();
		}

		private void Update()
		{
			_playerMovement.CanMove = _dialogueManager.GetPaused;
		}
		
		private void OnTriggerStay2D(Collider2D other)
		{
			if (!Input.GetKey(KeyCode.F)) return;
			_dialogueStarter = other.GetComponent<DialogueStarter>();
			_dialogueStarter.StartDialogue();
		}
	}
}
