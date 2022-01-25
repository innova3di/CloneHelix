using UnityEngine;
using System.Collections;

namespace CloneHelix
{
	public class NewBehaviourScript : MonoBehaviour {
		public Transform target;
		public float distance;
		public float height;
		public float damping;
		public bool smoothRotation = true;
		public bool followBehind = true;
		public float rotationDamping = 10.0f;
		public Vector3 currentPosition;

        private void Start()
        {
			currentPosition = transform.position;
        }

        void Update () {
			Vector3 wantedPosition;
			if(followBehind)
				wantedPosition = target.TransformPoint(0, height, -distance);
			else
				wantedPosition = target.TransformPoint(0, height, distance);

			transform.position = Vector3.Lerp (transform.position, wantedPosition, Time.deltaTime * damping);

			if (smoothRotation) {
				Quaternion wantedRotation = Quaternion.LookRotation(target.position - transform.position, target.up);
				transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
			}
			else transform.LookAt (target, target.up);

			if(GameManager.instance.startPanel.activeInHierarchy == true)
            {
				SetTransformPosition();
            }
		}

		public void SetTransformPosition()
        {
			transform.position = currentPosition;
		}
	}

}
