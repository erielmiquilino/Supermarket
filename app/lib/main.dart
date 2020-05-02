import 'package:app/http/webclient.dart';
import 'package:app/screens/carts/list.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(Supermarket());
}

class Supermarket extends StatelessWidget {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(
        primaryColor: Colors.red[900],
        accentColor: Colors.lightBlue[900],
        buttonTheme: ButtonThemeData(
          buttonColor: Colors.lightBlue[900],
          textTheme: ButtonTextTheme.primary,
        ),
      ),
      home: CartCardList(),
    );
  }
}
