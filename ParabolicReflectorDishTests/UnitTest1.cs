using System.Text.RegularExpressions;

namespace ParabolicReflectorDishTests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var dish = @"
O....#....
O.OO#....#
.....##...
OO.#O....O
.O.....O#.
O.#..O.#.#
..O..#O..O
.......O..
#....###..
#OO..#....
";
            var expected = @"
OOOO.#.O..
OO..#....#
OO..O##..O
O..#.OO...
........#.
..#....#.#
..O..#.O.O
..O.......
#....###..
#....#....
";
            Assert.That(Tilt(dish), Is.EqualTo(expected));
        }

        private string Tilt(string dish)
        {
            Console.WriteLine(dish);
            var newDish = Roll(dish);
            while (newDish != dish)
            {
                dish = newDish;
                Console.WriteLine(dish);
                newDish = Roll(dish);
            }

            return newDish;
        }

        private static string Roll(string dish)
        {
            return Regex.Replace(dish, @"(\.)(.{11})(O)", "$3$2$1",
                RegexOptions.Compiled | RegexOptions.Singleline);
        }
    }
}