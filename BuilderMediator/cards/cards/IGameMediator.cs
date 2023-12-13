namespace cards;

interface IGameMediator
{
    void HandleAttack(Card attacker, Card target);
    void HandleBuff(int buffAmount, Card target);
    void HandleHeal(int healAmount, Card target);
    void DiscardCard(Card card);
}