using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame21
{
    public class Game
    {
        private Deck deck;
        public GameState LastState { get; private set; }        //результат игры 
        public GameAction AllowedAction { get; private set; }   //возможность продолжения текущей игры
        public Player PlayerAI { get; private set; }
        public Player PlayerHuman { get; private set; }

        public Game(int firstPlayer)
        {
            if (firstPlayer == 0)
            {
                this.PlayerAI = new Player(true);
                this.PlayerHuman = new Player(false);
            }
            else
            {
                this.PlayerHuman = new Player(true);
                this.PlayerAI = new Player(false);
            }
            this.LastState = GameState.Unknown;
            this.AllowedAction = GameAction.Play;
        }

        public void Deal()
        {
            this.LastState = GameState.Unknown;
            this.AllowedAction = GameAction.Play;
            if (this.deck == null)
            {
                this.deck = new Deck();
            }
            else
            {
                this.deck.Populate();
            }

            this.deck.Shuffle();
            this.PlayerAI.Hand.Clear();
            this.PlayerHuman.Hand.Clear();

            if (this.PlayerAI.isFirst)
            {
                this.deck.Deal(this.PlayerAI.Hand);
                this.deck.Deal(this.PlayerHuman.Hand);
            }
            else
            {
                this.deck.Deal(this.PlayerHuman.Hand);
                this.deck.Deal(this.PlayerAI.Hand);
            }

            if ((this.PlayerAI.Hand.TotalValue() == 21) || (this.PlayerAI.Hand.TotalValue() == 22) &&
                (this.PlayerHuman.Hand.TotalValue() == 21) || (this.PlayerHuman.Hand.TotalValue() == 22))
            {
                this.LastState = GameState.Draw;
                this.AllowedAction = GameAction.Stop;
            }
            else if ((this.PlayerAI.Hand.TotalValue() == 21) || (this.PlayerAI.Hand.TotalValue() == 22))
            {
                this.LastState = GameState.AIWon;
                this.AllowedAction = GameAction.Stop;
            }
            else if ((this.PlayerHuman.Hand.TotalValue() == 21) || (this.PlayerHuman.Hand.TotalValue() == 22))
            {
                this.LastState = GameState.HumanWon;
                this.AllowedAction = GameAction.Stop;
            }
        }

        public void AskCard()
        {
            if (this.PlayerAI.isFirst)
            {
                if (PlayerAI.Hand.TotalValue() < 17)
                {
                    this.deck.GiveAdditionalCard(PlayerAI.Hand);
                    if (PlayerAI.Hand.TotalValue() >= 21)
                        AllowedAction = GameAction.Stop;
                }
                if (PlayerHuman.Hand.TotalValue() < 21)
                {
                    this.deck.GiveAdditionalCard(PlayerHuman.Hand);
                    if (PlayerHuman.Hand.TotalValue() >= 21)
                        AllowedAction = GameAction.Stop;
                }
            }
            else
            {
                if (PlayerHuman.Hand.TotalValue() < 21)
                {
                    this.deck.GiveAdditionalCard(PlayerHuman.Hand);
                    if (PlayerHuman.Hand.TotalValue() >= 21)
                        AllowedAction = GameAction.Stop;
                }
                if (PlayerAI.Hand.TotalValue() < 17)
                {
                    this.deck.GiveAdditionalCard(PlayerAI.Hand);
                    if (PlayerAI.Hand.TotalValue() >= 21)
                        AllowedAction = GameAction.Stop;
                }
            }

        }
        public void SkipCard()
        {
            if (PlayerAI.Hand.TotalValue() < 17)
            {
                this.deck.GiveAdditionalCard(PlayerAI.Hand);
                CheckValue();
            }
            
        }
        public void CheckValue()
        {
            int AI = PlayerAI.Hand.TotalValue();
            int Human = PlayerHuman.Hand.TotalValue();

            if (AI > 21)
            {
                if (Human > 21)
                {
                    if (AI < Human)
                    {
                        LastState = GameState.AIWon;
                        AllowedAction = GameAction.Stop;
                    }
                    else if (AI == Human)
                    {
                        LastState = GameState.Draw;
                        AllowedAction = GameAction.Stop;
                    }
                    else
                    {
                        LastState = GameState.HumanWon;
                        AllowedAction = GameAction.Stop;
                    }
                }
                else
                {
                    LastState = GameState.HumanWon;
                    AllowedAction = GameAction.Stop;
                }
            }
            else
            {
                if (Human <= 21)
                {
                    if (AI > Human)
                    {
                        LastState = GameState.AIWon;
                        AllowedAction = GameAction.Stop;
                    }
                    else if(AI == Human)
                    {
                        LastState = GameState.Draw;
                        AllowedAction = GameAction.Stop;
                    }
                    else
                    {
                        LastState = GameState.HumanWon;
                        AllowedAction = GameAction.Stop;
                    }
                }
                else
                {
                    LastState = GameState.AIWon;
                    AllowedAction = GameAction.Stop;
                }
            }
        }
    }
}
