using Godot;
using System;

public partial class KillBounds : Node2D
{
	[Signal]
	public delegate void OnEnterKillBoundsEventHandler(Node2D Body);

	// Called when the node enters the scene tree for the first time.
	public void OnPlayerEnteredKillBounds(Node2D Body) {
		EmitSignal(SignalName.OnEnterKillBounds, Body);
	}
}
