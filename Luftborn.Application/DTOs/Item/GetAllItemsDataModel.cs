namespace Luftborn.Application.DTOs
{
    public class GetAllItemsDataModel
    {
        public IEnumerable<GetItemDataModel> Items { get; set; } = new List<GetItemDataModel>();
    }
}