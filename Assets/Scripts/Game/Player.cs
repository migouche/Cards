using System;
using System.Collections.Generic;
using Game.Cards;
using UnityEngine;

namespace Game
{
    public class Player : MonoBehaviour
    {
        private Transform hand;

        private List<Card> cards;
        // Start is called before the first frame update
        void Start()
        {
            cards = new List<Card>();
        }

        // Update is called once per frame
        void Update()
        {
        
        }

    }
}
