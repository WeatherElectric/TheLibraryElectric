# TheLibraryElectric

A library for a BONELAB SDK thing I'm doing

## Current Functions:
* FreezeRigidbodies

  Freezes any RB in the scene.

  On start it will search for your rigmanager and store it, and apply a dummy component to any already kinematic RBs in the scene.
  It will ignore anything in your rigmanager and it will ignore any already kinematic RBs when freezing.

  Once destroyed it unfreezes everything to make sure that if you despawn the trigger, anything you froze gets unfrozen.

* KinematicRB

   A dummy component to mark what is already kinematic.

* DeleteOnCollision

  Destroys anything it touches, besides anything that's on the static layer and your rigmanager.

* CubeBreak

  Splits an object into many of itself with some force.
