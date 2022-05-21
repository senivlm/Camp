using Matrices;

Console.WriteLine("Vertical snake:");
Matrix m1 = new Matrix(3, 4);

m1.VerticalSnake();
m1.PrintMatrix();

Console.WriteLine("Diagonal snake:");
Matrix m2 = new Matrix(4);

m2.DiagonalSnake();
m2.PrintMatrix();

Console.WriteLine("Spiral snake:");
Matrix m3 = new Matrix(3, 4);

m3.SpiralSnake();
m3.PrintMatrix();

Console.WriteLine("Task from first stage:");
Matrix m4 = new Matrix(9);

m4.FirstStageTask();
m4.PrintMatrix();

Console.ReadKey();