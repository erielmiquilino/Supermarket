import 'package:app/models/cart.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';

class CartCardItem extends StatelessWidget{
  final Cart _cart;

  CartCardItem(this._cart);

  @override
  Widget build(BuildContext context) {
    return Card(
      child: ListTile(
        leading: FlutterLogo(size: 72.0),
        title: Text(_cart.place),
        subtitle: Text(_cart.purchaseDate.toString()),
      ),
    );
  }

}