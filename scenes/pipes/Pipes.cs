using Godot;
using System;

public partial class Pipes : Node2D
{
	[Export]
	public int moveSpeed = 100;

	[Export]
	Area2D ScoreZone = null;

    public override void _Ready()
    {
        GD.Print(this.Name + " instantiated.");
    }

    public void TranslateNegX(float delta)
	{
		Vector2 Movement = new Vector2(moveSpeed, 0) * delta;
		Position -= Movement;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		TranslateNegX((float)delta);
	}
}
