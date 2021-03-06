﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTDClasses
{
    public class PlayerTrain : Train
    {
        /// <summary>
        /// This is the player hand that correlates to this player train
        /// </summary>
        private Hand myHand;

        /// <summary>
        /// This is the boolean control variable to indicate whether this player train is open to other players
        /// </summary>
        private bool isTrainOpen = false;

        /// <summary>
        /// This is the most appropriate constructor for the class.
        /// </summary>
        /// <param name="h">Represents the Hand object to which the train belongs</param>
        /// <param name="engineValue">Represents the first playable value on the train</param>
        public PlayerTrain(Hand h, int engineValue) : base (engineValue)
        {
            myHand = h;
        }

        /// <summary>
        /// Returns whether or not the train is open.  An open train
        /// can be played upon by any player.
        /// </summary>
        public bool IsOpen => isTrainOpen;
        

        /// <summary>
        /// Open the train
        /// </summary>
        public void Open()
        {
            isTrainOpen = true;
        }

        /// <summary>
        /// Close the train
        /// </summary>
        public void Close()
        {
            isTrainOpen = false;
        }
        /// <summary>
        /// Can the domino d be played by the hand h on this train?
        /// If it can be played, must it be flipped to do so?
        /// </summary>
        /// <param name="d"></param>
        /// <param name="mustFlip"></param>
        /// <param name="h"></param>
        /// <returns></returns>
        public override bool IsPlayable(Hand h, Domino d, out bool mustFlip)
        {
            mustFlip = false;
            if (myHand != h && IsOpen == true)
            {
                if (IsPlayable(d, out mustFlip))
                    return true;
            }
            if (myHand == h)
            {
                if (IsPlayable(d, out mustFlip))
                    return true;
            }
            return false;
        }
    }
}
