# TheLibraryElectric

A library for a BONELAB SDK thing I'm doing

## Current Functions:
* FreezeAllRigidbodies

  Freezes any RB in the scene.

  On start it will search for your rigmanager and store it, and apply a dummy component to any already kinematic RBs in the scene.
  It will ignore anything in your rigmanager and it will ignore any already kinematic RBs when freezing.

* KinematicRB

   A dummy component to mark what is already kinematic.
