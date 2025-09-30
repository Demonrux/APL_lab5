using LinearAlgebra;

namespace DectorDemo
{
    class Program
    {
        static void Main()
        {
            var vector1 = new MathVector(1, 2, 3);
            var vector2 = new MathVector(4, 5, 6);
            var vector3 = new MathVector(7, 8);

            Console.WriteLine($"vector1:{vector1}\n");
            Console.WriteLine($"vector2:{vector2}\n");
            Console.WriteLine($"Size vector1:{vector1.Dimensions}\n");
            Console.WriteLine($"Len vector1:{vector1.Length}\n");

            TestMethods(vector1, vector2);
            TestOperators(vector1, vector2);
            TestExceptions(vector1, vector3);
        }

        static void TestMethods(MathVector vector1, MathVector vector2)
        {
            Console.WriteLine("Test methods...");

            var sumNumber = vector1.SumNumber(5);
            Console.WriteLine($"vector1.SumNumber(5) = {sumNumber}");

            var MultiplyNumber = vector2.MultiplyNumber(3);
            Console.WriteLine($"vector2.MultiplyNumber(3) = {MultiplyNumber}");

            var sumVectors = vector1.Sum(vector2);
            Console.WriteLine($"vector1.MultiplyNumber(3) = {sumVectors}");

            var multiplyVectors = vector2.Multiply(vector2);
            Console.WriteLine($"vector2.Multiply(vector2) = {multiplyVectors}");

            var scalarMultiplyVectors = vector1.ScalarMultiply(vector2);
            Console.WriteLine($"vector1.ScalarMultiply(vector2) = {scalarMultiplyVectors}");

            var distance = vector1.CalcDistance(vector2);
            Console.WriteLine($"CalcDistance(vector2) = {distance}");

            Console.WriteLine("Test methods OK\n");
        }

        static void TestOperators(MathVector vector1, MathVector vector2)
        {
            Console.WriteLine("Test operators...");

            Console.WriteLine($"vector1 + 6 = {vector1 + 6}");
            Console.WriteLine($"vector2 - 3 = {vector2 - 3}");
            Console.WriteLine($"vector1 * 4 = {vector1 * 4}");
            Console.WriteLine($"vector2 / 2 = {vector2 / 2}");

            Console.WriteLine($"vector1 + vector2 = {vector1 + vector2}");
            Console.WriteLine($"vector1 - vector2 = {vector1 - vector2}");
            Console.WriteLine($"vector1 * vector2 = {vector1 * vector2}");
            Console.WriteLine($"vector1 / vector2 = {vector1 / vector2}");

            Console.WriteLine("Test operators OK\n");
        }

        static void TestExceptions(MathVector vector1, MathVector vector2)
        {
            Console.WriteLine("\nTesting exceptions...");

            try
            {
                Console.WriteLine("Testing index out of range...");
                var temp = vector1[-1];
            }
            catch (ArgumentOutOfRangeException error)
            {
                Console.WriteLine(error.Message);
            }

            try
            {
                Console.WriteLine("Testing index out of range (upper bound)...");
                var temp = vector1[10];
            }
            catch (ArgumentOutOfRangeException error)
            {
                Console.WriteLine(error.Message);
            }

            try
            {
                Console.WriteLine("Testing different dimensions for Sum...");
                var result = vector1.Sum(vector2);
            }
            catch (Exception error)
            {
                Console.WriteLine($"Caught exception for different dimensions in Sum: {error.GetType().Name} - {error.Message}");
            }

            try
            {
                Console.WriteLine("Testing different dimensions for Multiply...");
                var result = vector1.Multiply(vector2);
            }
            catch (Exception error)
            {
                Console.WriteLine($"Caught exception for different dimensions in Multiply: {error.GetType().Name} - {error.Message}");
            }

            try
            {
                Console.WriteLine("Testing different dimensions for ScalarMultiply...");
                var result = vector1.ScalarMultiply(vector2);
            }
            catch (Exception error)
            {
                Console.WriteLine($"✓ Caught exception for different dimensions in ScalarMultiply: {error.GetType().Name} - {error.Message}");
            }

            try
            {
                Console.WriteLine("Testing division by zero in vector division...");
                var zeroVector = new MathVector(0, 0, 0);
                var result = vector1 / zeroVector;
            }
            catch (DivideByZeroException error)
            {
                Console.WriteLine(error.Message);
            }

            try
            {
                Console.WriteLine("Testing division by zero in scalar division...");
                var result = vector1 / 0;
            }
            catch (DivideByZeroException error)
            {
                Console.WriteLine(error.Message);
            }

            try
            {
                Console.WriteLine("Testing negative vector size...");
                var negativeVector = new MathVector(-5);
            }
            catch (ArgumentOutOfRangeException error)
            {
                Console.WriteLine(error.Message);
            }

            try
            {
                Console.WriteLine("Testing null in constructor...");
                double[] nullArray = null;
                var nullVector = new MathVector(nullArray);
            }
            catch (ArgumentNullException error)
            {
                Console.WriteLine(error.Message);
            }

            Console.WriteLine("Testing exceptions OK\n");
        }
    }
}
