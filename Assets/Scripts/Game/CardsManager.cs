using System.Collections;
using System.Collections.Generic;
using Game.Cards;
using UnityEngine;

namespace Game
{
    public class GameData
    {
        public int rounds; // 0 = unlimited
        public int roundPhases; // 0 won't call phasse calls, 1 will call, even if its technically the same (just the round)
        public Deck deck;
    }
    public class CardsManager : MonoBehaviour
    {
        private GameData gameData;

        public TextAsset deck;

        public Player player; // other players will be managed by the server
        private int currentPlayerIndex;
        private bool gameEnded;

        // Start is called before the first frame update
        void Start()
        {
            // obv this will be done outside later
            Deck deckData = Deck.FromJSON(this.deck);

            // for now:
            gameData = new GameData
            {
                deck = deckData,
                rounds = 10,
                roundPhases = 0
            };

            StartCoroutine(PlayGame());
        }

        IEnumerator StartGame(){yield return null;}
        IEnumerator StartRound(){yield return null;}

        IEnumerator PlayRound(){yield return null;}

        IEnumerator EndRound(){yield return null;}
        IEnumerator EndGame(){yield return null;}


        IEnumerator PlayGame()
        {
            yield return StartGame();

            if (gameData.rounds == 0)
            {
                while (!gameEnded)
                {
                    yield return StartRound();
                    yield return PlayRound();
                    yield return EndRound();
                }
            }
            else
            {
                for (int i = 0; i < gameData.rounds; i++)
                {
                    yield return StartRound();
                    yield return PlayRound();
                    yield return EndRound();
                }
            }

            yield return EndGame();
            yield return null;
        }
    }
}
