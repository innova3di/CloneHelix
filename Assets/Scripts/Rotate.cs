﻿using UnityEngine;
using System.Collections;


namespace CloneHelix
{
	[RequireComponent(typeof(MeshRenderer))]

	public class Rotate : MonoBehaviour 
	{

		#region ROTATE
		public float _sensitivity = 5f;
		private Vector3 _mouseReference;
		private Vector3 _mouseOffset;
		private Vector3 _rotation = Vector3.zero;
		private bool _isRotating;


		#endregion

		void Update()
		{
			if(_isRotating && GameManager.instance.startGame == true)
			{
				// offset
				_mouseOffset = (Input.mousePosition - _mouseReference);

				// apply rotation
				_rotation.y = -(_mouseOffset.x + _mouseOffset.y) * _sensitivity;

				// rotate
				gameObject.transform.Rotate(_rotation);

				// store new mouse position
				_mouseReference = Input.mousePosition;
			}
		}

		void OnMouseDown()
		{
			// rotating flag
			_isRotating = true;

			// store mouse position
			_mouseReference = Input.mousePosition;
		}

		void OnMouseUp()
		{
			// rotating flag
			_isRotating = false;
		}

	}
}