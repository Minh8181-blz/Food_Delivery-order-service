namespace FoodEstablishment.Application.Dtos.Base
{
    public class PaginationQueryModel
    {
        private int _page;
        private int _size;

        public PaginationQueryModel()
        {
            _page = 1;
            _size = 20;
        }

        public int Page {
            get => _page;
            set
            {
                _page = value > 0 ? value : 1;
            }
        }
        public int Size {
            get => _size;
            set
            {
                _size = value > 0 ? value : 20;
            }
        }
    }
}
