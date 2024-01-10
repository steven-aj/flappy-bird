using Godot;
using System;

public partial class PipeFactory : Marker2D
{
	[Export]
	PackedScene BluePipes;

    [Export]
	double minYOffset = -100;

	[Export]
	double maxYOffset = 100;

	[Export]
	public int spawnDelay = 1000;

    public override void _Ready()
    {
        SpawnPipes();
    }

    private Vector2 GetRandomPosition()
	{
		float xPos = Position.X;
		float yPos = (float)GD.RandRange(minYOffset, maxYOffset);
		return new Vector2(xPos, yPos);
	}

	public void SpawnPipes()
	{
        Node2D Pipes = BluePipes.Instantiate<Node2D>();
		Pipes.Position = GetRandomPosition();
		AddChild(Pipes, true);
    }
}
