using Godot;
using System;

public partial class Player : RigidBody2D
{
	[Export]
	public int flapStrength = 100;

    [Export]
    public int score = 0;

    [Signal]
    public delegate void OnIncrementScoreEventHandler(Player Player);

    private AnimationPlayer Animation;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Animation = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public void ReadFlapActions() {
		if (Input.IsActionJustPressed("flap")) {
			this.LinearVelocity = new Vector2(0, -flapStrength);
			Animation.Play("flap");
		}
	}

    public void IncrementScore(int scoreValue)
    {
        this.score += scoreValue;
		EmitSignal(SignalName.OnIncrementScore, this);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
		ReadFlapActions();
	}
}
