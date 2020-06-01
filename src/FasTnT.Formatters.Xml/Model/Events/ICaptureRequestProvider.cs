using FasTnT.Domain.Commands;

namespace FasTnT.Formatters.Xml.Model.Events
{
    public interface ICaptureRequestProvider
    {
        ICaptureRequest GetEpcisCaptureRequest();
    }
}
