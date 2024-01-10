using Godot;
using System;

public partial class Pipes : Node2D
{
	[Export]
	public int moveSpeed = 80;

	[Export]
	Area2D ScoreZone = null;

    public void SlideLeft(float delta)
	{
		Vector2 Movement = new Vector2(moveSpeed, 0) * delta;
		Position -= Movement;
	}

	public void Despawn()
	{
		if (GlobalPosition.X <= -200)
		{
			QueueFree();
		}
	}

	public Player OnScoreZoneEntered(Player Player)
	{
		Player.IncrementScore(1);
		return Player;
	}


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		SlideLeft((float)delta);
		Despawn();
	}
}
