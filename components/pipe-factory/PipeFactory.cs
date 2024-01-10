using Godot;
using System;

public partial class PipeFactory : Marker2D
{
	[Export]
	PackedScene BluePipes;

	[ExportGroup("Y-axis Offset Range")]
	[Export]
	public double minOffset = -100;
	[Export]
	public double maxOffset = 100;

	private Timer SpawnTimer;

	private Vector2 GetRandomPosition()
	{
		float xPos = GlobalPosition.X;
		float yPos = (float)GD.RandRange(minOffset, maxOffset);
		return new Vector2(xPos, yPos);
	}

	private void SpawnPipes()
	{
		Node2D Pipes = BluePipes.Instantiate<Node2D>();
		Pipes.GlobalPosition = GetRandomPosition();
		AddChild(Pipes, true);
	}

	public override void _Ready()
	{
		SpawnTimer = GetNode<Timer>("SpawnTimer");
	}

	public void Start()
	{
		SpawnPipes();
		SpawnTimer.Start();
	}

	public void Stop()
	{
		SpawnTimer.Stop();
	}

	public void Reset() {
		var Pipes = GetChildren();
		foreach (var Pipe in Pipes) {
			Pipe.QueueFree();
		}
		Start();
	}
}
