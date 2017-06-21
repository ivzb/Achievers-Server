using Microsoft.AspNetCore.Mvc;

namespace Achievers.Models.Cars
{
    public class CarRequestModel
    {
        private int page;

        public const int PageSize = 2;
        
        public int Page
        {
            get
            {
                if (this.page == 0)
                {
                    return 1;
                }
                else
                {
                    return this.page;
                }
            }
            set
            {
                this.page = value;
            }
        }
        
        public string Search { get; set; }
    }
}
