using Godot;
using System;

public partial class Game : Node
{
	private Player Player;
	private GUI GUI;
	private Label ScoreLabel;
	private Button PlayButton;
	private Button ResetButton;
	private PipeFactory PipeFactory;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GUI = GetNode<GUI>("GUI");
		ScoreLabel = GUI.GetNode<Label>("ScoreLabel");
		PlayButton = GUI.GetNode<Button>("PlayButton");
		ResetButton = GUI.GetNode<Button>("ResetButton");
		PipeFactory = GetNode<PipeFactory>("PipeFactory");
		Player = GetNode<Player>("Player");
		Player.Idle(true);
	}

	public void OnStart() {
		Player.Idle(false);
		PipeFactory.Start();
	}

	public void OnReset() {
		GUI.Reset();
		Player.Reset();
		PipeFactory.Reset();
	}

	public void OnPlayerIncrementScore(Player Player)
	{
		GUI.OnPlayerIncrementScore(Player);
	}

	public void OnPlayerDie(Player Player) {
		GUI.EndGame();
		PipeFactory.Stop();
	}

	public void OnPlayerEnteredKillBounds(Node2D KillBoundsArea) {
		PipeFactory.Stop();
		Player.Die(KillBoundsArea);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
