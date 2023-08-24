# TheLibraryElectric

A library for a BONELAB SDK thing I'm doing

## Usage In Own Project

Drag the scripts inside of DummyScripts into your unity project.

When invoking methods, use UltEvents. Do not use Unity Events or it will crash the game.

You can use this in another code mod too, just reference the DLL.

## Current Functions:
* FreezeRigidbodies

  Freezes any RB in the scene.

  On start it will search for your rigmanager and store it, and apply a dummy component to any already kinematic RBs in the scene.
  It will ignore anything in your rigmanager and it will ignore any already kinematic RBs when freezing.

  Once destroyed it unfreezes everything to make sure that if you despawn the trigger, anything you froze gets unfrozen.

* DoNotFreeze

  Prevents FreezeRigidbodies from freezing the object. Must be on the same object as the rigidbody.

* DeleteOnCollision

  Destroys anything it touches, besides anything that's on the static layer and your rigmanager.

* DoNotDestroy

  Prevents DeleteOnCollision from destroying the gameobject and any children. Put on root.

* SendSignal

  Finds any RecieveSignal components in the scene that have the same key as them, and then call their method.

* RecieveSignal

  When called, it invokes an ultevent on it's gameobject.

* TimescaleController

  Increments the timescale by 1, can decrease as well but can't go negative

* ExplodeButBetter

  SLZ's simple explosion force, but it constantly runs unless inactive

* MrSplitter

  Splits an object into smaller versions of itself, keeping any components and child gameobjects
