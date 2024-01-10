using Godot;
using System;

public partial class ScoreZone : Area2D
{
	[Signal]
	public delegate RigidBody2D OnPlayerScoredEventHandler(RigidBody2D Player);

	public void OnPlayerEntered(RigidBody2D Player) {
		GD.Print(Player.Name + " has scored a point!");
		EmitSignal(SignalName.OnPlayerScored, Player);
	}
}
