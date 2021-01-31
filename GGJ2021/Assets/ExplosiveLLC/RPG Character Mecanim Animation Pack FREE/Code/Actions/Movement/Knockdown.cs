using UnityEngine;

namespace RPGCharacterAnimsFREE.Actions
{
    public class Knockdown : MovementActionHandler<HitContext>
    {
        public Knockdown(RPGCharacterMovementController movement) : base(movement)
        {
        }

        public override bool CanStartAction(RPGCharacterController controller)
        {
            return !controller.isKnockdown;
        }

        protected override void _StartAction(RPGCharacterController controller, HitContext context)
        {
            int hitNumber = context.number;
            Vector3 direction = context.direction;
            float force = context.force;
            float variableForce = context.variableForce;

            if (hitNumber == -1) {
                hitNumber = AnimationData.RandomHitNumber("Knockdown");
                direction = AnimationData.HitDirection("Knockdown", hitNumber);
                direction = controller.transform.rotation * direction;
            } else {
                if (context.relative) { direction = controller.transform.rotation * direction; }
            }

            controller.Knockdown(hitNumber);
            movement.KnockbackForce(direction, force, variableForce);
            movement.currentState = RPGCharacterState.Knockdown;
			controller.SetIKPause(5.25f);
        }

        public override bool IsActive()
        {
            return movement.currentState != null && (RPGCharacterState)movement.currentState == RPGCharacterState.Knockdown;
        }
    }
}