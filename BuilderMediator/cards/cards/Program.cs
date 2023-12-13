namespace cards;

public class Program
{
    static void Main(string[] args)
    {
        var builder = new CardBuilder();
        var director = new CardDirector();

        // Player cards
        director.ConstructBasicCreatureCard(builder);
        Card c1 = builder.Build();
        builder.Reset();
        director.ConstructBasicBuffCard(builder);
        Card c2 = builder.Build();
        builder.Reset();
        builder.SetName("Strong Heal")
            .SetRarity(1)
            .SetManaCost(1)
            .SetDeployHeal(3);
        Card c3 = builder.Build();
        builder.Reset();
        
        var playerCards = new Dictionary<string, Card>
        {
            {"p_crt", c1},
            {"p_buff", c2},
            {"p_heal", c3}
        };

        // Enemy cards
        Card c4 = builder.SetName("Powerful Creature")
            .SetRarity(2)
            .SetManaCost(3)
            .SetAttackDamage(4)
            .SetHealth(2)
            .Build();

        var enemyCards = new Dictionary<string, Card>
        {
            {"e_crt", c4}
        };
        

        // Game mediator
        var mediator = new GameMediator(10, playerCards, enemyCards);

        
        // Interface
        while (true)
        {
            // Display enemy cards
            Console.WriteLine("Enemy Cards:");
            foreach (var card in enemyCards)
            {
                Console.WriteLine($"- {card.Key} : {card.Value}");
            }
            
            Console.WriteLine();
            
            // Display player cards
            Console.WriteLine("Your Cards:");
            foreach (var card in playerCards)
            {
                Console.WriteLine($"- {card.Key} : {card.Value}");
            }
            
            // Choose card
            Console.WriteLine("Choose a card to play (type the key):");
            string chosenCardKey = Console.ReadLine();
            
            if (!playerCards.ContainsKey(chosenCardKey))
            {
                Console.WriteLine("Invalid card. Try again.");
                continue;
            }

            Card chosenCard = playerCards[chosenCardKey];

            // Display possible target cards
            Dictionary<string, Card> targetCards = mediator.GetTargetCards(chosenCard);
            
            Console.WriteLine("Target Cards:");
            foreach (var card in targetCards)
            {
                Console.WriteLine($"- {card.Key} : {card.Value}");
            }
            
            Console.WriteLine("Choose a card to target (type the key):");
            string targetCardKey = Console.ReadLine();
            
            if (!targetCards.ContainsKey(targetCardKey))
            {
                Console.WriteLine("Invalid card. Try again.");
                continue;
            }
            
            Card targetCard = targetCards[targetCardKey];

            // Perform the action
            chosenCard.ExecuteOn(targetCard);
            
            // Check for win/lose conditions
            if (mediator.CheckWinCondition())
            {
                Console.WriteLine("You win!");
                break;
            }

            if (mediator.CheckLoseCondition())
            {
                Console.WriteLine("You lose.");
                break;
            }
        }
    }
}