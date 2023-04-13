namespace CURD_in_dot_net_6_and_identity.Data.EntityModel
{
    public partial class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public DateTime? StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
    }
}
