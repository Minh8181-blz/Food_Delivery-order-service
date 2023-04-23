namespace FoodEstablishment.Domain.OrderStatuses
{
    public enum OrderPlacementStatus
    {
        DRAFT,
        PLACED,
        CANCELED,
    }

    public enum OrderShippingStatus
    {
        UNSHIPPED,
        SHIPPING,
        SHIPPED,
    }

    public enum OrderAcceptanceStatus
    {
        AWAITING,
        ACCEPTED,
        DECLINED,
    }

    public enum OrderPaymentStatus
    {
        UNPAID,
        PAID,
    }
}
