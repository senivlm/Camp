using Matrices;

Matrix m1 = new Matrix(3, 4);

m1.VerticalSnake();
m1.PrintMatrix();

Matrix m2 = new Matrix(4);

m2.DiagonalSnake();
m2.PrintMatrix();

Matrix m3 = new Matrix(3, 4);

m3.SpiralSnake();
m3.PrintMatrix();

Matrix m4 = new Matrix(9);
m4.FirstStageTask();
m4.PrintMatrix();

Console.ReadKey();