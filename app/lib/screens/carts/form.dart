import 'package:app/Components/cartItemCardItem.dart';
import 'package:app/models/cardItem.dart';
import 'package:app/models/cart.dart';
import 'package:app/models/product.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:flutter/widgets.dart';

class CartForm extends StatefulWidget {
  @override
  State<StatefulWidget> createState() {
    return CartFormState();
  }
}

class CartFormState extends State<CartForm> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Adicione itens ao seu carrinho'),
      ),
      body: SingleChildScrollView(
        child: Column(
          children: <Widget>[
            AddCartItem(),
          ],
        ),
      ),
    );
  }
}

class AddCartItem extends StatefulWidget {
  final List<CartItem> _cartItems = List();

  @override
  State<StatefulWidget> createState() {
    return AddCartItemState();
  }
}

class AddCartItemState extends State<AddCartItem> {
  final FocusNode focus = new FocusNode();
  final TextEditingController _product = new TextEditingController();
  final TextEditingController _quantity = new TextEditingController();
  final TextEditingController _price = new TextEditingController();

  final TextEditingController _place = new TextEditingController();

  DateTime _purchaseDate = DateTime.now();

  AddCartItemState();

  Future _selectDate() async {
    DateTime picked = await showDatePicker(
        context: context,
        initialDate: _purchaseDate,
        firstDate: new DateTime(2016),
        lastDate: new DateTime(2022));
    if (picked != null && picked != _purchaseDate)
      setState(() {
        _purchaseDate = picked;
      });
  }

  String _formatDate(DateTime dateTime) {
    return new DateFormat.yMd().format(dateTime);
  }

  void _createCartCard(BuildContext context) {
    Cart cart = new Cart(
        place: _place.text,
        purchaseDate: _purchaseDate,
        cartItems: widget._cartItems);
    Navigator.pop(context, cart);
  }

  Future _showDialogCreateCartCard(BuildContext context) async {
    Dialog dialog = Dialog(
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(12.0),
      ),
      child: Container(
        height: 300,
        width: 300,
        child: Column(
          children: <Widget>[
            Align(
              alignment: Alignment.center,
              child: Text("É Isso ai?"),
            ),
            TextField(
              controller:
                  TextEditingController(text: _formatDate(_purchaseDate)),
              decoration: InputDecoration(
                labelText: 'Data da compra',
                icon: Icon(Icons.calendar_today),
                suffixIcon: IconButton(
                  icon: Icon(Icons.date_range),
                  onPressed: () => _selectDate(),
                ),
              ),
            ),
            TextField(
              controller: _place,
              decoration: InputDecoration(
                icon: Icon(Icons.map),
                labelText: 'Local da compra',
              ),
            ),
            Align(
              alignment: Alignment.center,
              child: RaisedButton(
                onPressed: () => _createCartCard(context),
                child: const Text('Ok, Vai dar certo!'),
              ),
            )
          ],
        ),
      ),
    );

    return showDialog(context: context, builder: (BuildContext context) => dialog);
  }

  void _createCartItemCard() {
    CartItem cartItem = new CartItem(
      product: new Product(description: _product.text),
      quantity: double.parse(_quantity.text),
      price: double.parse(_price.text),
    );

    setState(() {
      widget._cartItems.add(cartItem);
    });

    _product.clear();
    _quantity.clear();
    _price.clear();

    focus.requestFocus();
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      child: Column(
        children: <Widget>[
          Form(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: <Widget>[
                TextFormField(
                  autofocus: true,
                  focusNode: focus,
                  controller: _product,
                  textInputAction: TextInputAction.next,
                  decoration: InputDecoration(
                      icon: Icon(Icons.shop), labelText: 'Produto'),
                  onFieldSubmitted: (_) => FocusScope.of(context).nextFocus(),
                ),
                TextFormField(
                  controller: _quantity,
                  keyboardType: TextInputType.number,
                  textInputAction: TextInputAction.next,
                  decoration: InputDecoration(
                      icon: Icon(Icons.exposure), labelText: 'Quantidade'),
                  onFieldSubmitted: (_) => FocusScope.of(context).nextFocus(),
                ),
                TextFormField(
                  controller: _price,
                  keyboardType: TextInputType.number,
                  textInputAction: TextInputAction.next,
                  decoration: InputDecoration(
                      icon: Icon(Icons.monetization_on), labelText: 'Preço'),
                  onFieldSubmitted: (_) => FocusScope.of(context).nextFocus(),
                ),
              ],
            ),
          ),
          RaisedButton(
            onPressed: () => _createCartItemCard(),
            child: const Text('Incluir'),
          ),
          Container(
            height: MediaQuery.of(context).size.height * 0.38,
            child: ListView.builder(
              itemCount: widget._cartItems.length,
              itemBuilder: (context, index) {
                var reverseList = widget._cartItems.reversed.toList();
                final cartItem = reverseList[index];
                return CartItemCardItem(cartItem);
              },
            ),
          ),
          RaisedButton(
            onPressed: () => _showDialogCreateCartCard(context)
                .then((cart) => Navigator.pop(context, cart)),
            child: const Text('Salvar'),
          )
        ],
      ),
    );
  }
}
