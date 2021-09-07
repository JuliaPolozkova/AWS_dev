using Amazon.SQS;
using Amazon.SQS.Model;
using System.Text.Json;
using System.Threading.Tasks;

namespace OnlineShop.QueueService
{
    public class SQSService
	{
        private const string _sqsUrl = "https://sqs.us-east-1.amazonaws.com/127964315183/cart.fifo";
        private const int _maxMessages = 7;

        public static async Task<string> SendMessage(IAmazonSQS sqsClient, string messageBody)
        {
            SendMessageRequest request = new SendMessageRequest(_sqsUrl, messageBody);
            request.MessageGroupId = "testQueue";
            SendMessageResponse responseSendMsg = await sqsClient.SendMessageAsync(request);
            return $"HttpStatusCode: {responseSendMsg.HttpStatusCode}";
        }

        public static async Task<ReceiveMessageResponse> GetMessage()
        {
            IAmazonSQS sqsClient = new AmazonSQSClient();
            return await sqsClient.ReceiveMessageAsync(new ReceiveMessageRequest
            {
                QueueUrl = _sqsUrl,
                MaxNumberOfMessages = _maxMessages,
                WaitTimeSeconds = 10
            });
        }
    }
}
