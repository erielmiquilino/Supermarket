import 'package:app/Components/cartCardItem.dart';
import 'package:app/models/cart.dart';
import 'package:app/screens/carts/form.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';

class CartCardList extends StatefulWidget {
  final List<Cart> _carts = List();

  @override
  State<StatefulWidget> createState() {
    return CartCardListState();
  }
}

class CartCardListState extends State<CartCardList> {

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Supermarket'),
      ),
      body: ListView.builder(
        itemCount: widget._carts.length,
        itemBuilder: (context, index) {
          final cart = widget._carts[index];
          return CartCardItem(cart);
        },
      ),
      floatingActionButton: FloatingActionButton(
        child: Icon(Icons.add_shopping_cart),
        onPressed: () {
          Navigator.push(context, MaterialPageRoute(builder: (context) {
            return CartForm();
          })).then((cart) => _updateList(cart));
        },
      ),
    );
  }

  void _updateList(Cart cart) {
    if (cart != null) {
      setState(() {
        widget._carts.add(cart);
      });
    }
  }

}



