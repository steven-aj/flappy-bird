using Godot;
using System;

public partial class GUI : Control
{
	private Label ScoreLabel;
	private Label FinalScoreLabel;
	private Button PlayButton;
	private Button ResetButton;

	[Signal]
	public delegate void OnPlayButtonClickedEventHandler();

	[Signal]
	public delegate void OnResetButtonClickedEventHandler();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScoreLabel = GetNode<Label>("ScoreLabel");
		FinalScoreLabel = GetNode<Label>("FinalScoreLabel");
		PlayButton = GetNode<Button>("PlayButton");
		ResetButton = GetNode<Button>("ResetButton");
	}

	public void OnClickPlayButton() {
		PlayButton.Visible = false;
		EmitSignal(SignalName.OnPlayButtonClicked);
	}

	public void OnClickResetButton() {
		ResetButton.Visible = false;
		EmitSignal(SignalName.OnResetButtonClicked);
	}

	public void OnPlayerIncrementScore(Player Player)
	{
		ScoreLabel.Text = Player.score.ToString();
	}

	public void EndGame(Player Player) {
		FinalScoreLabel.Text = "Final Score: " + Player.score;
		FinalScoreLabel.Visible = true;
		ResetButton.Visible = true;
	}

	public void Reset() {
		ScoreLabel.Text = "0";
		FinalScoreLabel.Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
