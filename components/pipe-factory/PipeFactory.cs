using Godot;
using System;

public partial class PipeFactory : Marker2D
{
	[Export]
	PackedScene BluePipes;

    [Export]
    public int spawnDelay = 1000;

    [ExportGroup("Y-axis Offset Range")]
    [Export]
	double minOffset = -100;

	[Export]
	double maxOffset = 100;

    public override void _Ready()
    {
        SpawnPipes();
    }

    private Vector2 GetRandomPosition()
	{
		float xPos = Position.X;
		float yPos = (float)GD.RandRange(minOffset, maxOffset);
		return new Vector2(xPos, yPos);
	}

	public void SpawnPipes()
	{
        Node2D Pipes = BluePipes.Instantiate<Node2D>();
		Pipes.Position = GetRandomPosition();
		AddChild(Pipes, true);
    }
}
