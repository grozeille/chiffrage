namespace Chiffrage.App.ViewModel
{
    public struct CatalogViewModel
    {
        public int Id { get; set; }

        public string SupplierName { get; set; }

        public string Comment { get; set; }

        /*public string SupplyCategoryFilter { get; set; }

        public BindingList<CatalogSupplyViewModel> FilteredSupplies
        {
            get
            {
                if (string.IsNullOrEmpty(this.SupplyCategoryFilter))
                    return new BindingList<CatalogSupplyViewModel>(this.Supplies);
                else
                {
                    var regex = new Regex(string.Format(".*{0}.*", this.SupplyCategoryFilter));
                    return new BindingList<CatalogSupplyViewModel>(this.Supplies.Where((s) => s.Category != null && regex.IsMatch(s.Category)).ToList());
                }
            }
        }

        public BindingList<CatalogSupplyViewModel> Supplies { get; set; }

        public BindingList<CatalogHardwareViewModel> Hardwares { get; set; }

        public CatalogViewModel()
        {
            this.Supplies = new BindingList<CatalogSupplyViewModel>();
            this.Hardwares = new BindingList<CatalogHardwareViewModel>();
        }*/
    }
}