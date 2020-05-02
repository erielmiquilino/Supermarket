import 'package:app/models/cardItem.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';

class CartItemCardItem extends StatelessWidget {
  final CartItem _cartItem;

  CartItemCardItem(this._cartItem);

  @override
  Widget build(BuildContext context) {
    return Card(
      child: ListTile(
        leading: FlutterLogo(size: 72.0),
        title: Text(_cartItem.product.description),
        subtitle: Text((_cartItem.price * _cartItem.quantity).toString()),
      ),
    );
  }
  
}
