using Business.Models;
using NUnit.Framework;

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
            var ticTacToe = new TicTacToe();         
            
            ticTacToe.Play(0);
            ticTacToe.Play(1);
            ticTacToe.Play(2);
            ticTacToe.Play(3);
            // Chack ganador
            var status = ticTacToe.Play(4);
            if (status != GameStatus.Active)
            {
                Assert.Fail();
            }
            else
            {
                status = ticTacToe.Play(5);
                if (status != GameStatus.Active)
                {
                    Assert.Fail();
                }
                else
                {
                    status = ticTacToe.Play(6);

                    if (status == GameStatus.Winner)
                    {
                        Assert.Pass();
                    }
                    else
                    {
                        Assert.Fail();
                    }                   
                }
            }
        }

        //[Test]
        //public void WinnerTestCircle()
        //{
        //    TicTacToe ticTacToe = new TicTacToe();

        //    int position = 0;
        //    List<int> tieList = new List<int>() { 3, 0, 4, 1, 8, 2 };

        //    while (ticTacToe.Play(ticTacToe.GetNextPlayer(), tieList[position]) != 3)
        //    {
        //        position++;
        //    }
        //    var result = position;
        //    Assert.Pass();
        //}

        //[Test]
        //public void TieTest()
        //{
        //    TicTacToe ticTacToe = new TicTacToe();

        //    int position = 0;
        //    List<int> tieList = new List<int>() { 0, 1, 2, 3, 5, 4, 6, 8, 7 };

        //    while (ticTacToe.Play(ticTacToe.GetNextPlayer(), tieList[position]) == 0)
        //    {
        //        position++;
        //    }
        //    var result = position;
        //    Assert.Pass();
        //}
    }
}