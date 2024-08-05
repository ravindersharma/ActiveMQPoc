using Apache.NMS;
using Apache.NMS.ActiveMQ;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Producer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IConnection connection;
        private ISession session;
        private IMessageProducer producer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Init() {

            Uri connecturi = new Uri("activemq:tcp://localhost:61616");
            ConnectionFactory connectionFactory = new ConnectionFactory(connecturi);

            // Create a Connection
            this.connection = connectionFactory.CreateConnection();
            this.connection.Start();

            // Create a Session
            this.session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);

            // Get the destination (Topic or Queue)
            IDestination destination = this.session.GetQueue("testQueue");

            // Create a MessageProducer from the Session to the Topic or Queue
            this.producer = this.session.CreateProducer(destination);
            this.producer.DeliveryMode = MsgDeliveryMode.NonPersistent;

        }


        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a messages
            String text = "Test msg : " + DateTime.Now;
            ITextMessage message = session.CreateTextMessage(text);

            // Tell the producer to send the message
            this.producer.Send(message);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Clean up
            session.Close();
            connection.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Init();
        }
    }
}