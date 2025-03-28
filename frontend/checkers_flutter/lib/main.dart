import 'package:flutter/material.dart';
import 'services/signalr_service.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      home: SignalRTestScreen(),
    );
  }
}

class SignalRTestScreen extends StatefulWidget {
  const SignalRTestScreen({super.key});

  @override
  State<SignalRTestScreen> createState() => _SignalRTestScreenState();
}

class _SignalRTestScreenState extends State<SignalRTestScreen> {
  final SignalRService signalRService = SignalRService();

  final TextEditingController messageController = TextEditingController();

  @override
  void initState() {
    super.initState();
    signalRService.initConnection();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('SignalR Flutter Test')),
      body: Padding(
        padding: const EdgeInsets.all(20.0),
        child: Column(
          children: [
            TextField(
              controller: messageController,
              decoration: const InputDecoration(labelText: 'Wiadomość'),
            ),
            const SizedBox(height: 20),
            ElevatedButton(
              onPressed: () {
                signalRService.sendMessage("FlutterUser", messageController.text);
                messageController.clear();
              },
              child: const Text('Wyślij wiadomość'),
            ),
          ],
        ),
      ),
    );
  }
}
