namespace Day05;

public class AlmanacThing
{
    public long DescRangeStart { get; set; }
    public long SourceRangeStart { get; set; }
    public long Lenght { get; set; }

    /// <summary>Returns -1 if fails, otherwise the destination</summary>
    public long GetDestinatio(long number)
    {

        //number -= 1;
        if (SourceRangeStart <= number)
        {
            if (SourceRangeStart + Lenght >= number)
            {
                var offset = number - SourceRangeStart;
                var destination = DescRangeStart + offset;

                if (destination >= DescRangeStart && destination <= DescRangeStart + Lenght)
                {
                    return destination;
                }


            }
        }
        return -1;
    }

}


public class Input
{
    public List<long> Seeds { get; set; }
    public IEnumerable<long> SeedsP2 { get; set; }
    public Dictionary<string, List<AlmanacThing>> Almanacs { get; set; }

}



