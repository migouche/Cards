using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Game.Cards
{
    public class Deck
    {
        [System.Serializable]
        private class DeckData
        {
            [System.Serializable]
            public class CardData
            {
                public uint id;
                public string path;
            }
            public string c_object;
            public string c_type;
            public string c_back;
            public List<CardData> c_cards;
        }
        // Read JSON and get all info
        private Dictionary<uint, Sprite> cards;
        private Sprite cardBack;

        public static Deck FromJSON(String path) => FromJSON(new TextAsset(File.ReadAllText(path)));

        public static Deck FromJSON(TextAsset json)
        {
            DeckData data = JsonUtility.FromJson<DeckData>(json.text);


            if (data.c_object != "deck")
            {
                throw new Exception("Not a deck");
            }

            Deck deck = new Deck();
            deck.cards = new Dictionary<uint, Sprite>();
            foreach (DeckData.CardData card in data.c_cards)
            {
                deck.cards[card.id] = Resources.Load<Sprite>(card.path);
            }
            deck.cardBack = Resources.Load<Sprite>(data.c_back);
            return deck;

        }

    }
}
