using System;

namespace ILoveArcane;

public partial class MainPage : ContentPage
{
    private List<int> diceRolls = new List<int>();
    private int allPoints = 0;
    int points { get; set; }
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnRollDiceClicked(object sender, EventArgs e)
    {
        
        List<int> currentRolls = new List<int>();
        Random random = new Random();
        for (int i = 0; i < 5; i++)
        {
            currentRolls.Add(random.Next(1, 7));
        }

        
        Dice1.Source = $"k{currentRolls[0]}.png";
        Dice2.Source = $"k{currentRolls[1]}.png";
        Dice3.Source = $"k{currentRolls[2]}.png";
        Dice4.Source = $"k{currentRolls[3]}.png";
        Dice5.Source = $"k{currentRolls[4]}.png";


        
        diceRolls.AddRange(currentRolls);
        int points = CalculatePoints();
        allPoints = allPoints + points;
        diceRolls.Clear();
        PointsLabel.Text = $"Points: {allPoints}";
        DiceResult.Text = $"🎲 You rolled: {string.Join(", ", currentRolls)}";

    }
    private int CalculatePoints()
    {
        
        var groupedRolls = diceRolls.GroupBy(x => x);

        
        int points = groupedRolls
            .Where(g => g.Count() > 1)
            .Sum(g => g.Sum());

        return points;
    }
    private void OnResetClicked(object sender, EventArgs e)
    {
        diceRolls.Clear();
        allPoints = 0;
        PointsLabel.Text = $"Points: {allPoints}";
    }
}