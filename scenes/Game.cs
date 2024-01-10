using Godot;
using System;

public partial class Game : Node
{
	private Player Player;
	private Control GUI;
	private Label ScoreLabel;
	private Button PlayButton;
	private PipeFactory PipeFactory;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GUI = GetNode<Control>("GUI");
		ScoreLabel = GUI.GetNode<Label>("ScoreLabel");
		PlayButton = GUI.GetNode<Button>("PlayButton");
		PipeFactory = GetNode<PipeFactory>("PipeFactory");
		Player = GetNode<Player>("Player");
		Player.Idle(true);
	}

	public void OnPlayButtonClicked() {
		PlayButton.Visible = false;
		Player.Reset();
		Player.Idle(false);
		PipeFactory.Start();
	}

	public void OnPlayerIncrementScore(Player Player)
	{
		ScoreLabel.Text = Player.score.ToString();
	}

	public void OnPlayerDie(Player Player) {
		PipeFactory.Stop();
		PlayButton.Text = "Play Again";
		PlayButton.Visible = true;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
