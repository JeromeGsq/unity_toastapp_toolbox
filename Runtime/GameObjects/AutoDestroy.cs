namespace Toastapp.GameObjects
{
	using System.Collections;
	using UnityEngine;

	public class AutoDestroy : MonoBehaviour
	{
		[SerializeField]
		private float delay = 1;

		private void OnEnable()
		{
			Destroy(this.gameObject, this.delay);
		}
	}
}
