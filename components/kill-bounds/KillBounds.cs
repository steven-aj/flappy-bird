using Godot;
using System;

public partial class KillBounds : Node2D
{
	[Signal]
	public delegate void OnEnterKillBoundsEventHandler(Node2D KillBoundsArea);

	// Called when the node enters the scene tree for the first time.
	public void OnPlayerEnteredKillBounds() {
		EmitSignal(SignalName.OnEnterKillBounds, this);
	}
}
