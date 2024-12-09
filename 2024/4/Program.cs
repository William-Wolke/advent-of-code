namespace day4;

class Program
{
    static void Main(string[] args)
    {
        Part1();
        Part2();
    }
    static void Part1()
    {
        StreamReader sr = new StreamReader("./input.txt");
        List<Char[]> grid = new List<Char[]>();
        String? line;
        line = sr.ReadLine();
        while (line != null)
        {
            Char[] lineArr = line.ToCharArray();
            if (lineArr.Length > 0)
            {
                grid.Add(lineArr);
            }
            line = sr.ReadLine();
        }
        Int32 count = 0;
        Int32 y = 0;
        foreach (Char[] row in grid)
        {
            Int32 x = 0;
            foreach (Char item in row)
            {
                Int32 xmasCount = GetXmasCount(grid, x, y);
                if (xmasCount > 0)
                {
                    count += xmasCount;
                }
                x++;
            }
            y++;
        }
        Console.WriteLine(count);
    }
    static Int32 GetXmasCount(List<Char[]> grid, Int32 x, Int32 y)
    {
        if (grid[x][y] != 'X')
        {
            return 0;
        }
        Boolean checkLeft = x >= 3;
        Boolean checkRight = x + 3 < grid[y].Length;
        Boolean checkTop = y >= 3;
        Boolean checkBottom = y + 3 < grid.Count;
        Int32 count = 0;
        if (checkLeft && CheckXmas(grid[x][y], grid[x-1][y], grid[x-2][y], grid[x-3][y]))
        {
            count++;
        }
        if (checkLeft && checkTop && CheckXmas(grid[x][y], grid[x-1][y-1], grid[x-2][y-2], grid[x-3][y-3]))
        {
            count ++;
        }
        if (checkTop && CheckXmas(grid[x][y], grid[x][y-1], grid[x][y-2], grid[x][y-3]))
        {
            count++;
        }
        if (checkRight && checkTop && CheckXmas(grid[x][y], grid[x+1][y-1], grid[x+2][y-2], grid[x+3][y-3]))
        {
            count ++;
        }
        if (checkRight && CheckXmas(grid[x][y], grid[x+1][y], grid[x+2][y], grid[x+3][y]))
        {
            count++;
        }
        if (checkRight && checkBottom && CheckXmas(grid[x][y], grid[x+1][y+1], grid[x+2][y+2], grid[x+3][y+3]))
        {
            count ++;
        }
        if (checkBottom && CheckXmas(grid[x][y], grid[x][y+1], grid[x][y+2], grid[x][y+3]))
        {
            count++;
        }
        if (checkLeft && checkBottom && CheckXmas(grid[x][y], grid[x-1][y+1], grid[x-2][y+2], grid[x-3][y+3]))
        {
            count ++;
        }
        return count;
    }
    static Boolean CheckXmas(Char v1, Char v2, Char v3, Char v4)
    {
        return v1.ToString() + v2.ToString() + v3.ToString() + v4.ToString() == "XMAS";
    }
    static void Part2()
    {
        StreamReader sr = new StreamReader("./input.txt");
        List<Char[]> grid = new List<Char[]>();
        String? line;
        line = sr.ReadLine();
        while (line != null)
        {
            Char[] lineArr = line.ToCharArray();
            if (lineArr.Length > 0)
            {
                grid.Add(lineArr);
            }
            line = sr.ReadLine();
        }
        Int32 count = 0;
        Int32 y = 0;
        foreach (Char[] row in grid)
        {
            Int32 x = 0;
            foreach (Char item in row)
            {
                Int32 xmasCount = GetMasCount(grid, x, y);
                if (xmasCount > 0)
                {
                    count += xmasCount;
                }
                x++;
            }
            y++;
        }
        Console.WriteLine(count);
    }
    static Int32 GetMasCount(List<Char[]> grid, Int32 x, Int32 y)
    {
        if (grid[x][y] != 'A')
        {
            return 0;
        }
        Boolean checkLeft = x >= 1;
        Boolean checkRight = x + 1 < grid[y].Length;
        Boolean checkTop = y >= 1;
        Boolean checkBottom = y + 1 < grid.Count;
        if (!checkLeft || !checkRight || !checkTop || !checkBottom)
        {
            return 0;
        }
        if (!CheckMas(grid[x-1][y-1], grid[x][y], grid[x+1][y+1]))
        {
            return 0;
        }
        if (!CheckMas(grid[x-1][y+1], grid[x][y], grid[x+1][y-1]))
        {
            return 0;
        }
        return 1;
    }

    static Boolean CheckMas(Char v1, Char v2, Char v3)
    {
        Char[] arr = new Char[3];
        arr[0] = v1;
        arr[1] = v2;
        arr[2] = v3;
        String str = new String(arr);
        Array.Reverse(arr);
        String revStr = new String(arr);
        return str == "MAS" || revStr == "MAS";
    }
}
