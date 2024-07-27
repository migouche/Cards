using System;
using UnityEngine;

namespace Game.Cards
{
    public abstract class CardData
    {
        public abstract string Name();
        public abstract uint Identifier();
    }
}
