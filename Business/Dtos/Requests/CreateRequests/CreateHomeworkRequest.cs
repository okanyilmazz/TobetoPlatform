using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CreateHomeworkRequest
{
    public Guid OccupationClassId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string FilePath { get; set; }
    public DateTime Deadline { get; set; }
}
