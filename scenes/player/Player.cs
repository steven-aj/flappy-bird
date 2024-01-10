using Godot;
using System;

public partial class Player : RigidBody2D
{
	[Export]
	public int flapStrength = 100;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void ReadFlapActions() {
		if (Input.IsActionJustPressed("flap")) {
			this.LinearVelocity = new Vector2(0, -flapStrength);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ReadFlapActions();
	}
}
