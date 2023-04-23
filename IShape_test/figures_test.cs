namespace IShape_test
{
    public class Tests
    {
        // Square test
        [TestCase(1)]
        [TestCase(3)]
        public void SetSquareSide_ValidSideNoExeption(int side)
        {
            //Arrange
            var square = new Square();
            //Act & Assert
            Assert.DoesNotThrow(() => square.Side = side);
        }

        [TestCase(-1)]
        public void SetSquareSide_ValidSide_Exeption(int side)
        {
            //Arrange
            var square = new Square();
            //Act & Assert
            Assert.Throws<ArgumentException>(() => square.Side = side);
        }

        [TestCase(1)]
        public void Square_CalculatePerimeter_NoExeption(int side)
        {
            //Arrange
            var square = new Square();
            square.Side = side; 
            //Act & Assert
            Assert.DoesNotThrow(() => square.CalculatePerimeter());
        }

        [TestCase(1)]
        public void Square_CalculateArea_NoExeption(int side)
        {
            //Arrange
            var square = new Square();
            square.Side = side;

            //Act & Assert
            Assert.DoesNotThrow(() => square.CalculateArea());
        }

        //Triangle test
        [TestCase(3, 4, 5)]
        [TestCase(5, 6, 7)]
        public void SetTriangleSide_ValidSideNoExeption(int first_side, int second_side, int third_side)
        {
            //Arrange
            var triangle = new Triangle();
            //Act & Assert
            Assert.DoesNotThrow(() => { triangle.FirstSide = first_side; triangle.SecondSide = second_side; triangle.ThirdSide = third_side; });
        }
        
        [TestCase(-3, 4, 5)]
        public void SetTriangleSide_ValidSide_Exeption(int first_side, int second_side, int third_side)
        {
            //Arrange
            var triangle = new Triangle();
            //Act & Assert
            Assert.Throws<ArgumentException>(() => { triangle.FirstSide = first_side; triangle.SecondSide = second_side; triangle.ThirdSide = third_side; });
        }

        [TestCase(3, 4, 5)]
        public void Triangle_CalculatePerimeter_NoExeption(int first_side, int second_side, int third_side)
        {
            //Arrange
            var triangle = new Triangle();
            triangle.FirstSide = first_side; 
            triangle.SecondSide = second_side;
            triangle.ThirdSide = third_side;
            //Act & Assert
            Assert.DoesNotThrow(() => triangle.CalculatePerimeter());
        }

        [TestCase(3, 4, 5)]
        public void Triangle_CalculateArea_NoExeption(int first_side, int second_side, int third_side)
        {
            //Arrange
            var triangle = new Triangle();
            triangle.FirstSide = first_side;
            triangle.SecondSide = second_side;
            triangle.ThirdSide = third_side;

            //Act & Assert
            Assert.DoesNotThrow(() => triangle.CalculateArea());
        }

        //Circle test
        [TestCase(1)]
        [TestCase(3)]
        public void SetCircleSide_ValidSideNoExeption(int radius)
        {
            //Arrange
            var circle = new Circle();
            //Act & Assert
            Assert.DoesNotThrow(() => circle.Radius = radius);
        }

        [TestCase(-1)]
        public void SetCircleSide_ValidSide_Exeption(int radius)
        {
            //Arrange
            var circle = new Circle();
            //Act & Assert
            Assert.Throws<ArgumentException>(() => circle.Radius = radius);
        }

        [TestCase(1)]
        public void Circle_CalculatePerimeter_NoExeption(int radius)
        {
            //Arrange
            var circle = new Circle();
            circle.Radius = radius;
            //Act & Assert
            Assert.DoesNotThrow(() => circle.CalculatePerimeter());
        }

        [TestCase(1)]
        public void Circle_CalculateArea_NoExeption(int radius)
        {
            //Arrange
            var circle = new Circle();
            circle.Radius = radius;

            //Act & Assert
            Assert.DoesNotThrow(() => circle.CalculateArea());
        }
    }
}