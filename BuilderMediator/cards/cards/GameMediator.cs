namespace cards;

class GameMediator : IGameMediator
{
    private int _currentEnergy;
    private Dictionary<string, Card> _playerCards;
    private Dictionary<string, Card> _enemyCards;

    public GameMediator(int startingEnergy, Dictionary<string, Card> playerCards, Dictionary<string, Card> enemyCards)
    {
        _currentEnergy = startingEnergy;
        _playerCards = playerCards;
        _enemyCards = enemyCards;

        foreach (var card in _playerCards.Values)
        {
            card.SetMediator(this);
        }

        foreach (var card in _enemyCards.Values)
        {
            card.SetMediator(this);
        }
    }

    public void HandleAttack(Card attacker, Card target)
    {
        target.TakeDamage(attacker.AttackDamage);
        attacker.TakeDamage(target.AttackDamage);
    }

    public void HandleBuff(int buffAmount, Card target)
    {
        target.Buff(buffAmount);
    }

    public void HandleHeal(int healAmount, Card target)
    {
        target.Heal(healAmount);
    }
    
    public void DiscardCard(Card card)
    {
        if (_playerCards.Values.Contains(card))
        {
            var item = _playerCards.First(kvp => kvp.Value == card);
            _playerCards.Remove(item.Key);
        }
        else if (_enemyCards.Values.Contains(card))
        {
            var item = _enemyCards.First(kvp => kvp.Value == card);
            _enemyCards.Remove(item.Key);
        }
    }

    public Dictionary<string, Card> GetTargetCards(Card chosenCard)
    {
        if (chosenCard.AttackDamage > 0)
        {
            return _enemyCards.Where(c => c.Value.Health > 0).ToDictionary(c => c.Key, c => c.Value);
        }
        if (chosenCard.DeployHeal > 0)
        {
            return _playerCards.Where(c => c.Value.Health > 0).ToDictionary(c => c.Key, c => c.Value);
        }
        if (chosenCard.DeployBuff > 0)
        {
            return _playerCards.Where(c => c.Value.AttackDamage > 0).ToDictionary(c => c.Key, c => c.Value);
        }

        return new Dictionary<string, Card>();
    }
    
    public bool CheckWinCondition()
    {
        return !_enemyCards.Values.Any(card => card.AttackDamage > 0);
    }

    public bool CheckLoseCondition()
    {
        return !_playerCards.Values.Any(card => card.AttackDamage > 0);
    }
}