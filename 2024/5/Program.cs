namespace _5;

class Program
{
    static void Main(string[] args)
    {
        Part1();
    }
    static void Part1()
    {
        List<Int32[]> rulePairs = new List<Int32[]>();
        List<Int32[]> pageUpdates = new List<Int32[]>();
        List<Int32[]> invalidPageUpdates = new List<Int32[]>();
        List<Int32[]> correctedPageUpdates = new List<Int32[]>();
        List<Int32> validMiddlePageUpdates = new List<Int32>();
        String[] lines = File.ReadAllLines("./input.txt");
        foreach (string line in lines)
        {
            if (line.Contains("|"))
            {
                var pair = line.Split("|");
                if (pair.Length < 2)
                {
                    continue;
                }
                rulePairs.Add([Int32.Parse(pair[0]), Int32.Parse(pair[1])]);
            }
            else if (line.Contains(","))
            {
                String[] values = line.Split(",");
                int[] pages = Array.ConvertAll(values, int.Parse);
                pageUpdates.Add(pages);
            }
        }
        foreach (Int32[] pages in pageUpdates)
        {
            Boolean isValidPages = true;
            foreach (Int32[] rulePair in rulePairs)
            {
                var indexRule0 = IndexOf(pages, rulePair[0]);
                var indexRule1 = IndexOf(pages, rulePair[1]);
                if (indexRule0 is null || indexRule1 is null)
                {
                    continue;
                }
                if (indexRule0 < indexRule1)
                {
                    continue;
                }
                isValidPages = false;
            }
            if (isValidPages)
            {
                Decimal count = pages.Count()/2;
                Int32 middle = Decimal.ToInt32(Math.Ceiling(count));
                validMiddlePageUpdates.Add(pages[middle]);
            }
            else
            {
                invalidPageUpdates.Add(pages);
            }
        }
        foreach (Int32[] invalidPages in invalidPageUpdates)
        {
            correctedPageUpdates.Add(SortPageUpdates(invalidPages, rulePairs));
        }
        Int32 sum = validMiddlePageUpdates.Sum();
        Console.WriteLine(sum);
        validMiddlePageUpdates = new List<Int32>();
        foreach (Int32[] validPages in correctedPageUpdates)
        {
            Decimal count = validPages.Count()/2;
            Int32 middle = Decimal.ToInt32(Math.Ceiling(count));
            validMiddlePageUpdates.Add(validPages[middle]);
        }
        sum = validMiddlePageUpdates.Sum();
        Console.WriteLine(sum);
    }
    static Int32? IndexOf(Int32[] arr, Int32 value)
    {
        var i = 0;
        foreach (Int32 v in arr)
        {
            if (v == value)
            {
                return i;
            }
            i++;
        }
        return null;
    }
    static Int32[] SortPageUpdates(Int32[] invalidPages, List<Int32[]> rulePairs)
    {
        Boolean isSorted = false;
        while (!isSorted)
        {
            Boolean isChanged = false;
            foreach (Int32[] rulePair in rulePairs)
            {
                var indexRule0 = IndexOf(invalidPages, rulePair[0]);
                var indexRule1 = IndexOf(invalidPages, rulePair[1]);
                if (indexRule0 is null || indexRule1 is null)
                {
                    continue;
                }
                if (indexRule0 < indexRule1)
                {
                    continue;
                }
                var temp = invalidPages[indexRule0.Value];
                invalidPages[indexRule0.Value] = invalidPages[indexRule1.Value];
                invalidPages[indexRule1.Value] = temp;
                isChanged = true;
            }
            if (!isChanged)
            {
                isSorted = true;
            }
        }
        return invalidPages;
    }
}
