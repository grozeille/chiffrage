namespace Chiffrage.App.ViewModel
{
    public class DealItemViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ProjectItemViewModel[] Projects { get; set; }
    }
}