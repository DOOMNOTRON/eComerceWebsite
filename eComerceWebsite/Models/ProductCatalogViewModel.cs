namespace eComerceWebsite.Models
{
    public class ProductCatalogViewModel
    {
        public ProductCatalogViewModel(List<Products> products, int lastPage, int currentPage)
        {
            Products = products;
            LastPage = lastPage;
            CurrentPage = currentPage;
        }

        public List<Products> Products { get; private set; }

        /// <summary>
        /// The last page of the catalog. Calculated by
        /// having a number of products divided by
        /// products per page
        /// </summary>
        public int LastPage { get; private set; }

        /// <summary>
        /// The current page the user is viewing
        /// </summary>
        public int CurrentPage { get; private set; }
    }
}
