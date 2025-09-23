namespace LeadSoft.Common.GlobalDomain.DTOs
{
    public abstract partial class DTOContactResponse : DTOResponse
    {
        public DTOContactResponse()
        {

        }

        public void SetPrimary() => IsPrimary = true;
    }
}
