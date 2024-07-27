using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Cards
{
    public class SpanishCard : CardData
    {

        public enum Suit
        {
            Oros, Copas, Espadas, Bastos
        }

        public enum Rank
        {
            Uno, Dos, Tres, Cuatro, Cinco, Seis, Siete, Sota, Caballo, Rey
        }

        public Suit suit;
        public Rank rank;

        public SpanishCard(Suit suit, Rank rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public override string Name()
        {
            return $"{rank} de {suit}";
        }

        public override uint Identifier()
        {
            return (uint)suit * 10 + (uint)rank;
        }

    }
}
