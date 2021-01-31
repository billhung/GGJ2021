using System.Collections;
using UnityEngine;

namespace RPGCharacterAnimsFREE
{
    public class IKHands : MonoBehaviour
    {
        private Animator animator;
        private RPGCharacterWeaponController rpgCharacterWeaponController;
        public Transform leftHandObj;
        public Transform attachLeft;
        public bool canBeUsed;
		public bool isUsed;
        [Range(0, 1)] public float leftHandPositionWeight;
        [Range(0, 1)] public float leftHandRotationWeight;
        private Transform blendToTransform;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            rpgCharacterWeaponController = GetComponentInParent<RPGCharacterWeaponController>();
        }

        private void OnAnimatorIK(int layerIndex)
        {
            if (leftHandObj != null) {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, leftHandPositionWeight);
                animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, leftHandRotationWeight);
				if (attachLeft) {
					animator.SetIKPosition(AvatarIKGoal.LeftHand, attachLeft.position);
					animator.SetIKRotation(AvatarIKGoal.LeftHand, attachLeft.rotation);
				}
            }
        }

        public IEnumerator _BlendIK(bool blendOn, float delay, float timeToBlend, int weapon)
        {
            if (canBeUsed) {
                // If using 2 handed weapon.
                if (weapon == 1 || weapon == 2 || weapon == 3 || weapon == 5 || weapon == 18) {
					if (blendOn) { isUsed = true; }
					if (!blendOn) { isUsed = false; }
                    GetCurrentWeaponAttachPoint(weapon);
					yield return new WaitForSeconds(delay);
					float t = 0f;
					float blendTo = 0;
					float blendFrom = 0;
					if (blendOn) {
						blendTo = 1;
					} else {
						blendFrom = 1;
					}
					while (t < 1) {
						t += Time.deltaTime / timeToBlend;
						attachLeft = blendToTransform;
						leftHandPositionWeight = Mathf.Lerp(blendFrom, blendTo, t);
						leftHandRotationWeight = Mathf.Lerp(blendFrom, blendTo, t);
						yield return null;
					}
                }
            }
        }

		public IEnumerator _SetIKPause(float pauseTime)
		{
			float t = 0f;
			while (t < 1) {
				t += Time.deltaTime / 0.1f;
				leftHandPositionWeight = Mathf.Lerp(1, 0, t);
				leftHandRotationWeight = Mathf.Lerp(1, 0, t);
				yield return null;
			}
			yield return new WaitForSeconds(pauseTime - 0.2f);
			t = 0f;
			while (t < 1) {
				t += Time.deltaTime / 0.1f;
				leftHandPositionWeight = Mathf.Lerp(0, 1, t);
				leftHandRotationWeight = Mathf.Lerp(0, 1, t);
				yield return null;
			}
		}

		private void GetCurrentWeaponAttachPoint(int weapon)
        {
            if (weapon == 1) {
                blendToTransform = rpgCharacterWeaponController.twoHandSword.transform.GetChild(0).transform;
            }
        }
    }
}