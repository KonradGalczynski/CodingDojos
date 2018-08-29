using FluentAssertions;
using TddEbook.TddToolkit;
using TennisSimplified;
using Xunit;

namespace TennisSimplifiedSpecification
{
    public class TennisMatchCalculatorModuleSpecification
    {
        [Fact]
        public void ShouldReturnLoveLoveResultWhenPlayersDidNotWinPoints()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);

            tennisMatchCalculator.GetResult().Should().Be("  0 -   0");
        }

        [Fact]
        public void ShouldReturnFifteenLoveResultWhenFirstPlayerWonOnePoint()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);
            tennisMatchCalculator.OnFirstPlayerWonBall();

            const string expected = " 15 -   0";
            tennisMatchCalculator.GetResult().Should().Be(expected);
        }

        [Fact]
        public void ShouldReturnThirtyLoveResultWhenFirstPlayerWonTwoPoints()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);

            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();

            const string expected = " 30 -   0";
            tennisMatchCalculator.GetResult().Should().Be(expected);
        }

        [Fact]
        public void ShouldReturnFortyLoveResultWhenFirstPlayerWonThreePoints()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);

            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();

            const string expected = " 40 -   0";
            tennisMatchCalculator.GetResult().Should().Be(expected);
        }

        [Fact]
        public void ShouldReturnLoveFifteenResultWhenSecondPlayerWonOnePoint()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);

            tennisMatchCalculator.OnSecondPlayerWonBall();

            const string expected = "  0 -  15";
            tennisMatchCalculator.GetResult().Should().Be(expected);
        }

        [Fact]
        public void ShouldReturnLoveThirtyResultWhenSecondPlayerWonTwoPoints()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);

            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();

            const string expected = "  0 -  30";
            tennisMatchCalculator.GetResult().Should().Be(expected);
        }

        [Fact]
        public void ShouldReturnLoveFortyResultWhenSecondPlayerWonThreePoints()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);

            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();

            const string expected = "  0 -  40";
            tennisMatchCalculator.GetResult().Should().Be(expected);
        }

        [Fact]
        public void ShouldReturnFifteenFifteenResultWhenBothPlayerWonOnePoint()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);

            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();

            const string expected = " 15 -  15";
            tennisMatchCalculator.GetResult().Should().Be(expected);
        }

        [Fact]
        public void ShouldReturnThirtyThirtyResultWhenBothPlayerWonTwoPoints()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);

            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();

            const string expected = " 30 -  30";
            tennisMatchCalculator.GetResult().Should().Be(expected);
        }

        [Fact]
        public void ShouldReturnDeuceResultWhenBothPlayerThreeTwoPoints()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);

            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();

            const string expected = "  Deuce  ";
            tennisMatchCalculator.GetResult().Should().Be(expected);
        }

        [Fact]
        public void ShouldReturnAdvForPlayer1ResultWhenBothPlayersWonThreeBallsAndPlayer1WonBall()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);

            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();

            const string expected = "Adv -    ";
            tennisMatchCalculator.GetResult().Should().Be(expected);
        }

        [Fact]
        public void ShouldReturnAdvForPlayer2ResultWhenBothPlayersWonThreeBallsAndPlayer2WonBall()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);

            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();

            const string expected = "    - Adv";
            tennisMatchCalculator.GetResult().Should().Be(expected);
        }

        [Fact]
        public void ShouldReturnAdvForPlayer1ResultWhenBothPlayersWonEqualNumberOfBallsAndPlayer1WonBall()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);

            var ballsWon = Any.UnsignedLongIntegerOtherThan(0, 1, 2, 3);
            for (ulong i = 0; i < ballsWon; i++)
            {
                tennisMatchCalculator.OnFirstPlayerWonBall();
                tennisMatchCalculator.OnSecondPlayerWonBall();

            }
            tennisMatchCalculator.OnFirstPlayerWonBall();

            const string expected = "Adv -    ";
            tennisMatchCalculator.GetResult().Should().Be(expected);
        }

        [Fact]
        public void ShouldReturnAdvForPlayer2ResultWhenBothPlayersWonEqualNumberOfBallsAndPlayer2WonBall()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);

            var ballsWon = Any.UnsignedLongIntegerOtherThan(0, 1, 2, 3);
            for (ulong i = 0; i < ballsWon; i++)
            {
                tennisMatchCalculator.OnFirstPlayerWonBall();
                tennisMatchCalculator.OnSecondPlayerWonBall();

            }
            tennisMatchCalculator.OnSecondPlayerWonBall();

            const string expected = "    - Adv";
            tennisMatchCalculator.GetResult().Should().Be(expected);
        }

        [Fact]
        public void ShouldReturnWonForPlayer1ResultWhenPlayer1WonBallFromAdv()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);

            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();

            const string expected = "Won -    ";
            tennisMatchCalculator.GetResult().Should().Be(expected);
        }

        [Fact]
        public void ShouldReturnWonForPlayer2ResultWhenPlayer2WonBallFromAdv()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);

            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();

            const string expected = "    - Won";
            tennisMatchCalculator.GetResult().Should().Be(expected);
        }

        [Fact]
        public void ShouldReturnWonForPlayer1ResultWhenPlayer1WonBallFromLongLastingAdv()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);

            var ballsWon = Any.UnsignedLongIntegerOtherThan(0, 1, 2, 3);
            for (ulong i = 0; i < ballsWon; i++)
            {
                tennisMatchCalculator.OnFirstPlayerWonBall();
                tennisMatchCalculator.OnSecondPlayerWonBall();

            }
            tennisMatchCalculator.OnFirstPlayerWonBall();
            tennisMatchCalculator.OnFirstPlayerWonBall();

            const string expected = "Won -    ";
            tennisMatchCalculator.GetResult().Should().Be(expected);
        }

        [Fact]
        public void ShouldReturnWonForPlayer2ResultWhenPlayer2WonBallFromLongLastingAdv()
        {
            var tennisMatchStateFactory = new TennisMatchStateFactory();
            var tennisMatchCalculator = new TennisMatchCalculator(tennisMatchStateFactory);

            var ballsWon = Any.UnsignedLongIntegerOtherThan(0, 1, 2, 3);
            for (ulong i = 0; i < ballsWon; i++)
            {
                tennisMatchCalculator.OnFirstPlayerWonBall();
                tennisMatchCalculator.OnSecondPlayerWonBall();

            }
            tennisMatchCalculator.OnSecondPlayerWonBall();
            tennisMatchCalculator.OnSecondPlayerWonBall();

            const string expected = "    - Won";
            tennisMatchCalculator.GetResult().Should().Be(expected);
        }
    }
}