namespace Toastapp.GameObjects
{
    using UnityEngine;

    public class FollowAnchor : MonoBehaviour
    {
        private Vector3 moveVelocity;
        private Vector3 scaleVelocity;

        [SerializeField]
        private Transform target;

        [SerializeField]
        private Vector3 deltaPos;
        [SerializeField]
        private Vector3 deltaScale;

        [SerializeField]
        private float dampTimePos = 0.2f;
        [SerializeField]
        private float dampTimeRotation = 0.2f;
        [SerializeField]
        private float dampTimeScale = 0.2f;

        private void FixedUpdate()
        {
            if (this.target == null)
            {
                return;
            }

            if (this.dampTimePos > -1)
            {
                this.transform.position = Vector3.SmoothDamp(
                    this.transform.position,
                    this.target.position + this.deltaPos,
                    ref this.moveVelocity,
                    this.dampTimePos
                );
            }

            if (this.dampTimeRotation > -1)
            {
                this.transform.rotation = Quaternion.Lerp(
                    this.transform.rotation,
                    this.target.rotation,
                    Time.deltaTime * this.dampTimeRotation);
            }

            if (this.dampTimeScale > -1)
            {
                this.transform.localScale = Vector3.SmoothDamp(
                    this.transform.localScale,
                    this.target.localScale + this.deltaScale,
                    ref this.scaleVelocity,
                    this.dampTimeScale
                );
            }
        }
    }
}
