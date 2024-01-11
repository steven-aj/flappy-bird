using Godot;
using System;
using System.Collections;
using System.Threading;

public partial class Player : RigidBody2D
{
	public bool isAlive;
	private bool isIdle;
	private bool doReset;
	private Vector2 startPosition;
	private AnimationPlayer Animation;

	[Export]
	public int flapStrength = 100;

	[Export]
	public int score = 0;

	[Signal]
	public delegate void OnIncrementScoreEventHandler(Player Player);

	[Signal]
	public delegate void OnDieEventHandler(Player Player);

	private void IdleStart() {
		this.isIdle = true;
		this.GravityScale = 0;
		Animation.Play("idle");
	}

	private void IdleStop() {
		this.isIdle = false;
		this.GravityScale = 0.25f;
		Animation.Stop();
	}

	private void ReadFlapActions()
	{
		if (!isIdle && Input.IsActionJustPressed("flap") && isAlive)
		{
			this.LinearVelocity = new Vector2(0, -flapStrength);
			this.Animation.Play("flap");
		}
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.isIdle = true;
		this.isAlive = true;
		this.startPosition = new Vector2(GlobalPosition.X, GlobalPosition.Y);
		this.Animation = GetNode<AnimationPlayer>("AnimationPlayer");
	}

	public void IncrementScore(int scoreValue)
	{
		if (isAlive)
		{
			this.score += scoreValue;
			EmitSignal(SignalName.OnIncrementScore, this);
		}
	}

	public void Idle(bool state)
	{
		if (state == true) IdleStart();
		else IdleStop();
	}

	public void Die(Node2D Body)
	{
		if (Body.Name != "Player")
		{
			this.isAlive = false;
			EmitSignal(SignalName.OnDie, this);
		}
	}

	public void Reset() {
		RotationDegrees = 0;
		this.score = 0;
		this.isAlive = true;
		this.doReset = true;
		this.Idle(false);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ReadFlapActions();
	}

    public override void _IntegrateForces(PhysicsDirectBodyState2D state)
    {
		if (doReset) {
			RotationDegrees = 0;
			GlobalTransform = new Transform2D(0, startPosition);
			LinearVelocity = new Vector2(0, 0);
			doReset = false;
		}
    }
}
