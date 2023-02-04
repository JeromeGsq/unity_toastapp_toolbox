namespace Toastapp.Utils
{
    using UnityEngine;
    using UnityEngine.Events;

    public class EventHelper : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent awakeEvent;

        [SerializeField]
        private UnityEvent onEnableEvent;

        [SerializeField]
        private UnityEvent startEvent;

        [SerializeField]
        private UnityEvent updateEvent;

        [SerializeField]
        private UnityEvent onDisableEvent;

        [SerializeField]
        private UnityEvent onDestroyEvent;

        private void Awake()
        {
            this.awakeEvent.Invoke();
        }

        private void OnEnable()
        {
            this.onEnableEvent.Invoke();
        }

        private void Start()
        {
            this.startEvent.Invoke();
        }

        private void Update()
        {
            this.updateEvent.Invoke();
        }

        private void OnDisable()
        {
            this.onDisableEvent.Invoke();
        }

        private void OnDestroy()
        {
            this.onDestroyEvent.Invoke();
        }
    }
}
