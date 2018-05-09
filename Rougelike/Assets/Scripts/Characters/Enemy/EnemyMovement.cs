using System;
using System.Collections;
using UnityEngine;

namespace Completed
{
    class EnemyMovement : IMovementBehavior
    {
        public Character currentCharacter { get; set; }

		public void SetControls()
		{
			throw new NotImplementedException ();
		}

        public void CheckMovement()
        {
            throw new NotImplementedException();
        }

        public IEnumerator SmoothMovement(Vector3 end)
        {
            throw new NotImplementedException();
        }
    }
}


