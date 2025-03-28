import 'package:signalr_netcore/signalr_client.dart';

class SignalRService {
  final String serverUrl = "http://10.0.2.2:5126/checkersHub";

  late HubConnection hubConnection;

  Future<void> initConnection() async {
    hubConnection = HubConnectionBuilder()
        .withUrl(serverUrl)
        .withAutomaticReconnect()
        .build();

    hubConnection.onclose(({error}) => print("Connection Closed: $error"));
    hubConnection.onreconnecting(({error}) => print("Reconnecting: $error"));
    hubConnection.onreconnected(({connectionId}) => print("Reconnected: $connectionId"));

    hubConnection.on("ReceiveMessage", _handleIncomingMessage);

    await hubConnection.start();
    print('Connected to SignalR');
  }

  void _handleIncomingMessage(List<dynamic>? arguments) {
    final user = arguments?[0] ?? 'Unknown';
    final message = arguments?[1] ?? '';
    print("Message from $user: $message");
  }

  Future<void> sendMessage(String user, String message) async {
    await hubConnection.invoke("SendMessage", args: [user, message]);
  }
}
