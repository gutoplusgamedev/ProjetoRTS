public interface IResourceReceiver 
{
	void ReceiveResource (int amount, ResourceType resource);
	bool AcceptResource (ResourceType resource);
}
