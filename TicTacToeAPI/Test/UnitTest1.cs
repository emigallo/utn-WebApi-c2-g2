using NUnit.Framework;
using System.Collections.Generic;
using TicTacToeBusiness.Models;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void WinnerTestCross()
        {
            TicTacToe ticTacToe = new TicTacToe();

            int position = 0;

            while(ticTacToe.Play(ticTacToe.GetNextPlayer(), position) != 1)
            {
                position++;
            }
            var result = position;
            Assert.Pass();
        }

        [Test]
        public void WinnerTestCircle()
        {
            TicTacToe ticTacToe = new TicTacToe();

            int position = 0;
            List<int> tieList = new List<int>() { 3, 0, 4, 1, 8, 2 };

            while (ticTacToe.Play(ticTacToe.GetNextPlayer(), tieList[position]) != 3)
            {
                position++;
            }
            var result = position;
            Assert.Pass();
        }

        [Test]
        public void TieTest()
        {
            TicTacToe ticTacToe = new TicTacToe();

            int position = 0;
            List<int> tieList = new List<int>() { 0, 1, 2, 3, 5, 4, 6, 8, 7 };

            while (ticTacToe.Play(ticTacToe.GetNextPlayer(), tieList[position]) == 0)
            {
                position++;
            }
            var result = position;
            Assert.Pass();
        }
    }
}